using System.Text.RegularExpressions;

namespace v1.Helper;

public static class AuthUserHelper  
{
    public static string GenerateValidUsername(string name)
    {
        if(string.IsNullOrWhiteSpace(name))
            return $"user_{Guid.NewGuid().ToString("N")[..8]}";
            
        // Remove special characters and limit length
        var cleaned = Regex.Replace(name, "[^A-Za-z0-9]", "");
        // Ensure minimum length and add random string if needed
        return cleaned.Length > 3 ? cleaned : $"{cleaned}{Guid.NewGuid().ToString("N")[..4]}";
    }

    public static string GenerateValidEmail(string name, string phoneNumber)
    {
        var cleanName = Regex.Replace(name, "[^A-Za-z0-9]", "").ToLower();
        var cleanPhone = Regex.Replace(phoneNumber, "[^0-9]", "");
        var phoneSuffix = cleanPhone.Length > 4 ? cleanPhone[^4..] : "0000";
        
        return $"{cleanName}_{phoneSuffix}@sms.com";  // More unique email format
    }
}