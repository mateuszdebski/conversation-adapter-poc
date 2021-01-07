using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ConversationAdapter.Domain.AccessControl;
using Microsoft.IdentityModel.Tokens;
using Vonage;

namespace ConversationAdapter.Infrastructure.Domain.AccessControl
{
    internal class JwtGenerator : IJwtGenerator
    {
        private JwtSecurityTokenHandler Handler { get; }

        public JwtGenerator()
        {
            Handler = new JwtSecurityTokenHandler();
        }

        public string Generate(string applicationId, string userId, AccessControlList acl, string key)
        {
            var rsa = PemParse.DecodePEMKey(key);
            var signingCredentials = new SigningCredentials(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256);

            var now = DateTime.UtcNow;
            var unixTimeSeconds = new DateTimeOffset(now).ToUnixTimeSeconds();
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), new Claim(JwtRegisteredClaimNames.Sub, userId),
                new Claim(JwtRegisteredClaimNames.Iat, unixTimeSeconds.ToString(), ClaimValueTypes.Integer64),
                new Claim("application_id", applicationId),
            };
            var claimsCollection = new Dictionary<string, object>
            {
                { "acl", acl }
            };
            var header = new JwtHeader(signingCredentials);
            var payload = new JwtPayload(null, null, claims, claimsCollection, now, now.AddMinutes(30), null);
            var descriptor = new JwtSecurityToken(header, payload);

            return Handler.WriteToken(descriptor);
        }
    }
}