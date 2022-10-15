using BirlesikOdeme.Core.Entities.Dtos;
using FluentValidation;

namespace BirlesikOdeme.API.Validation
{
    public class SalesValidator : AbstractValidator<SalesRequestModel>
    {
        public SalesValidator()
        {
            RuleFor(x => x.BankaAdi).NotNull().NotEmpty().WithMessage("Banka Adı alanı zorunludur.");
            RuleFor(x => x.KartNumarasi).NotNull().NotEmpty()
                .Must(w => w.ToString().Length == 16).WithMessage("Kart numarası alanı 16 karakter olmak zorundadır.");
            RuleFor(x => x.KartSonKullanmaAyi).NotNull().NotEmpty()
                .Must(w => w.ToString().Length == 2).WithMessage("Kart son kullanma ayı.");
            RuleFor(x => x.KartSonKullanmaYili).NotNull().NotEmpty()
                .Must(w => w.ToString().Length == 2).WithMessage("Kart son kullanma yılı son iki hanesi. Örn: 2025 ise 25 olarak giriniz.");
           
        }
    }
}
