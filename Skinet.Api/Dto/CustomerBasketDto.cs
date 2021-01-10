using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Skinet.Api.Dto
{
    public class CustomerBasketDto
    {
        [Required]
        public string Id { get; set; }
        public List<BasketItemDto> Items { get; set; } = new List<BasketItemDto>();
    }
}