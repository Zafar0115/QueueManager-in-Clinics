using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QueueManager.Application.TokenModels
{
    public class Token
    {
        public required string AccessToken { get; set; }
        public required string RefreshToken { get; set; }
    }
}
