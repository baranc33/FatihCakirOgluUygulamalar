using System.ComponentModel.DataAnnotations.Schema;

namespace NLayerApp.Core.Entites
{
    public class Product : BaseEntity
    {
        public string Name{ get; set; }
        public int Stock{ get; set; }
        public decimal Price{ get; set; }

        public int CategoryId { get; set; }
        //[ForeignKey("Category_Id")]// yukardaki isimlendirme kuralına uyulmicaksa
        // bu şekilde bir attribute yardımıyla belirtilmelidir
        public Category Category { get; set; }
        public ProductFeature ProductFeature { get; set; }
    }

}
