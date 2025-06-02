namespace ProjectPilot.Application.Common.Models;
public static class StringExtension
{
    public static string ToSnakeCase(this string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        // If the input is all uppercase, return it as lowercase
        if (input.All(char.IsUpper))
            return input.ToLower();


        var stringBuilder = new System.Text.StringBuilder();
        for (int i = 0; i < input.Length; i++)
        {
            char c = input[i];
            if (char.IsUpper(c))
            {
                // Add an underscore before uppercase letters (except the first letter).
                if (i > 0)
                {
                    stringBuilder.Append('_');
                }
                stringBuilder.Append(char.ToLower(c));
            }
            else
            {
                stringBuilder.Append(c);
            }
        }
        return stringBuilder.ToString();
    }
}
