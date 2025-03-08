using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using v1.DbContexts.AuthModels;
using v1.DbContexts.Models;
using v1.DTOs;
using v1.Helper;
using v1.Repository.IRepository;
using v1.Services.IService;

namespace v1.Services
{
    public class MerchantRegistrationService : IMerchantRegistrationServiceInterface
    {
        private readonly IMerchantBasicInterface _merchantRepository;
        private readonly IMerchantTypeInterface _merchantTypeRepository;
        private readonly ICardInterface _cardRepository;
        private readonly ICardTypeInterface _cardTypeRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public MerchantRegistrationService(
            IMerchantBasicInterface merchantRepository,
            IMerchantTypeInterface merchantTypeRepository,
            ICardInterface cardRepository,
            ICardTypeInterface cardTypeRepository,
            UserManager<ApplicationUser> userManager)
        {
            _merchantRepository = merchantRepository;
            _merchantTypeRepository = merchantTypeRepository;
            _cardRepository = cardRepository;
            _cardTypeRepository = cardTypeRepository;
            _userManager = userManager;
        }

        public async Task RegisterMerchantAsync(MerchantRegistrationDto merchantRegistrationDto)
        {
            // Step 1: Create and save merchants
            var merchants = await CreateMerchants(merchantRegistrationDto.Merchants);
            
            // Step 2: Create application users for visits
            var applicationUsers = await CreateApplicationUsers(merchantRegistrationDto.UserVisits);
            
            // Step 3: Create and save cards
            var cards = await CreateCards(merchantRegistrationDto.Cards, applicationUsers);
            
            // Step 4: Create merchant registration
            await CreateRegistration(merchantRegistrationDto, merchants, cards, applicationUsers);
        }

        // private async Task<List<MerchantBasicDetails>> CreateMerchants(List<MerchantDto> merchantDtos)
        // {
        //     var merchants = new List<MerchantBasicDetails>();
        //     
        //     foreach (var merchantDto in merchantDtos)
        //     {
        //         var merchantType = await _merchantTypeRepository.GetMerchantTypeByIdAsync(merchantDto.Type) 
        //             ?? throw new ArgumentException($"Invalid merchant type: {merchantDto.Type}");
        //
        //         var merchant = new MerchantBasicDetails
        //         {
        //             Id = Guid.NewGuid(),
        //             Name = merchantDto.Name,
        //             Area = merchantDto.Area,
        //             Phone = merchantDto.PhoneNumber,
        //             MerchantTypeId = merchantType.Id,
        //             Status = 1,
        //             VisitDate = DateTime.Now,
        //             CreateAt = DateTime.Now,
        //             IsDeleted = false
        //         };
        //         merchants.Add(merchant);
        //     }
        //     
        //     await _merchantRepository.AddMerchantsAsync(merchants);
        //     return merchants;
        // }

        private async Task<List<MerchantBasicDetails>> CreateMerchants(List<MerchantDto> merchantDtos)
        {
            var merchants = new List<MerchantBasicDetails>();
    
            foreach (var merchantDto in merchantDtos)
            {
                // 1. Create ApplicationUser first
                var user = new ApplicationUser
                {
                    UserName = AuthUserHelper.GenerateValidUsername(merchantDto.Name),
                    Email = AuthUserHelper.GenerateValidEmail(merchantDto.Name, merchantDto.PhoneNumber),
                    Name = merchantDto.Name.Trim(),
                    PhoneNumber = merchantDto.PhoneNumber,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    Status = 1
                };

                // 2. Create user with generated password
                var password = "p09oP)(O";
                var userResult = await _userManager.CreateAsync(user, password);
        
                if (!userResult.Succeeded)
                {
                    throw new InvalidOperationException(
                        $"User creation failed: {string.Join(", ", userResult.Errors)}");
                }

                // 3. Create merchant with user reference
                var merchantType = await _merchantTypeRepository.GetMerchantTypeByIdAsync(merchantDto.Type) 
                                   ?? throw new ArgumentException($"Invalid merchant type: {merchantDto.Type}");

                var merchant = new MerchantBasicDetails
                {
                    Id = Guid.NewGuid(),
                    Name = merchantDto.Name,
                    Area = merchantDto.Area,
                    Phone = merchantDto.PhoneNumber,
                    MerchantTypeId = merchantType.Id,
                    MerchantUserId = user.Id, // Link to the created user
                    Status = 1,
                    VisitDate = DateTime.UtcNow,
                    CreateAt = DateTime.UtcNow,
                    IsDeleted = false
                };
        
                merchants.Add(merchant);
            }
    
            // 4. Save all merchants
            await _merchantRepository.AddMerchantsAsync(merchants);
            return merchants;
        }
        
        
        private async Task<List<ApplicationUser>> CreateApplicationUsers(List<UserVisitDto> userVisitDtos)
        {
            var applicationUsers = new List<ApplicationUser>();
            
            foreach (var userVisitDto in userVisitDtos)
            {
                var user = new ApplicationUser
                {
                    UserName = AuthUserHelper.GenerateValidUsername(userVisitDto.Name),
                    Email = AuthUserHelper.GenerateValidEmail(userVisitDto.Name, userVisitDto.PhoneNumber),
                    Name = userVisitDto.Name.Trim(),
                    PhoneNumber = userVisitDto.PhoneNumber,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    Status = 0
                };

                var result = await _userManager.CreateAsync(user, "p09oP)(O");
                if (!result.Succeeded)
                {
                    throw new InvalidOperationException($"User creation failed in registration : {string.Join(", ", result.Errors)}");
                }
                
                applicationUsers.Add(user);
            }
            
            return applicationUsers;
        }

        private async Task<List<CardDetails>> CreateCards(List<CardDto> cardDtos, List<ApplicationUser> applicationUsers)
        {
            if (applicationUsers.Count == 0)
                throw new InvalidOperationException("No application users available for card creation");

            var cards = new List<CardDetails>();
            var userIndex = 0;

            foreach (var cardDto in cardDtos)
            {
                var cardType = await _cardTypeRepository.GetByIdAsync(cardDto.Type) 
                    ?? throw new ArgumentException($"Invalid card type: {cardDto.Type}");

                var card = new CardDetails
                {
                    Id = Guid.NewGuid(),
                    CardDetailsName = cardDto.CardholderName,
                    CardTypeId = cardType.Id,
                    Phone = cardDto.PhoneNumber,
                    ApplicationUserId = applicationUsers[userIndex % applicationUsers.Count].Id,
                    CreateAt = DateTime.Now,
                    IsDeleted = false
                };
                
                cards.Add(card);
                userIndex++;
            }
            
            await _cardRepository.AddCardsAsync(cards);
            return cards;
        }

        private async Task CreateRegistration(
            MerchantRegistrationDto dto,
            List<MerchantBasicDetails> merchants,
            List<CardDetails> cards,
            List<ApplicationUser> applicationUsers)
        {
            if (merchants.Count == 0 || cards.Count == 0 || applicationUsers.Count == 0)
                throw new InvalidOperationException("Cannot create registration without merchants, cards, or users");

            var registration = new MerchantRegistration
            {
                Id = Guid.NewGuid(),
                DepositCollection = dto.CheckCollection,
                VisitDate = DateOnly.FromDateTime(dto.VisitDate),
                MerchantDetailsId = merchants[0].Id,
                CardDetailsId = cards[0].Id,
                ApplicationUserId = applicationUsers[0].Id,
                CreateAt = DateTime.Now,
                IsDeleted = false
            };

            await _merchantRepository.AddRegistrationAsync(registration);
        }
    }
}