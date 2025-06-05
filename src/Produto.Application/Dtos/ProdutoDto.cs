namespace Produto.Application.Dtos
{
    public class ProdutoDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }

    public class CreateProdutoDto
    {        
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }


    public class UpdateProdutoDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }


}
