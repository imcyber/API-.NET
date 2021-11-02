using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using api.domain.Dtos;
using api.domain.Entities;
using api.domain.Interfaces.Services.User;
using api.domain.Repository;
using api.domain.Security;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace api.service.Services
{
    public class LoginService : ILoginService
    {
        private IUserRepository _repository;

        private SigningConfigurations _signingconfigurations;

        private TokenConfiguration _tokenconfiguration;

        private IConfiguration _iconfiguration { get; }

        public LoginService(IUserRepository repository,
                            SigningConfigurations signingconfigurations,
                            TokenConfiguration tokenconfiguration,
                            IConfiguration iconfiguration)
        {
            _repository = repository;
            _signingconfigurations = signingconfigurations;
            _tokenconfiguration = tokenconfiguration;
            _iconfiguration = iconfiguration;
        }

        public async Task<object> FindByLogin(LoginDto user)
        {
            var baseUser = new UserEntity();

            if (user.Email != null && !string.IsNullOrWhiteSpace(user.Email))
            {

                baseUser = await _repository.FindByLogin(user.Email);

                if (baseUser == null)
                {
                    return new
                    {
                        authenticated = false,
                        message = "Falha ao autenticar"
                    };
                }
                else
                {
                    ClaimsIdentity identity = new ClaimsIdentity(
                        new GenericIdentity(baseUser.email),
                        new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // JTI eh o id do token
                            new Claim(JwtRegisteredClaimNames.UniqueName, user.Email),
                        }
                    );

                    DateTime createDate = DateTime.Now;
                    DateTime expirationDate = createDate + TimeSpan.FromSeconds(_tokenconfiguration.Seconds); // tempo setado em TokenConfiguration
                    var handler = new JwtSecurityTokenHandler();
                    string token = CreateToken(identity, createDate, expirationDate, handler);
                    return SuccessObject(createDate, expirationDate, token, baseUser);

                }
            }

            else
            {
                return new
                {
                    authenticated = false,
                    message = "Falha ao autenticar"
                };
            }
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenconfiguration.Issuer,
                Audience = _tokenconfiguration.Audience,
                SigningCredentials = _signingconfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate
            });

            var token = handler.WriteToken(securityToken);
            return token;

        }

        private object SuccessObject(DateTime createDate, DateTime expirationDate, String token, UserEntity user)
        {
            return new
            {
                authenticated = true,
                created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                acessToken = token,
                username = user.email,
                name = user.name,
                message = "Logado com sucesso"
            };
        }


    }
}
