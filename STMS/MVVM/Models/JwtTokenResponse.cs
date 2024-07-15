using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace STMS.MVVM.Models
{
    public class JwtTokenResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("tokenCreationTime")]
        public DateTime CreationTime { get; set; }
        [JsonProperty("user")]
        public User User { get; set; }
    }
    public class User
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }
    }
}
