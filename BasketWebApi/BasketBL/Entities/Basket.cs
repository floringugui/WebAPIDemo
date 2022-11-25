using BasketBL.Enums;
using System.ComponentModel.DataAnnotations;

namespace BasketBL.Entities
{
    public class Basket : EntityBase<int>

    {
        public string Customer { get; set; }

        public bool paysVAT { get; set; }

        [EnumDataType(typeof(BasketStatus))]
        public BasketStatus Status { get; set; } = BasketStatus.Active;

        public virtual ICollection<Article> Articles { get; set; }
    }
}