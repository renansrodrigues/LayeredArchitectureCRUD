using FluentValidation.Results;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Produto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        [NotMapped]
        public ValidationResult validationResult { get; set; } = new ValidationResult();
    }
}
