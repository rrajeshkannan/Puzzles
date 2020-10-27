using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{
    static void Main(string[] args)
    {
        int N = Convert.ToInt32(Console.ReadLine());
        var firstNames = new string[N];
        var emailIds = new string[N];

        for (int NItr = 0; NItr < N; NItr++)
        {
            string[] firstNameEmailID = Console.ReadLine().Split(' ');

            firstNames[NItr] = firstNameEmailID[0];
            emailIds[NItr] = firstNameEmailID[1];
        }

        var result = firstNames
            .Zip(emailIds, (firstName, emailId) => new { firstName, emailId })
            .Where(nameEmail =>
            {
                // (@)(.+)$
                var emailDomain = Regex.Split(nameEmail.emailId, "(@)(.*)$");
                return ((emailDomain.Length > 2) && (emailDomain[2] == "gmail.com"));
            })
            .Select(nameEmail => nameEmail.firstName)
            .OrderBy(name => name);

        foreach (var item in result)
        {
            Console.WriteLine(item);
        }
    }
}
