using Fiap.Hackatoon.Product.Consumer.Domain.Entities;
using Fiap.Hackatoon.Product.Consumer.Tests.Shared.Fixtures.Utils;

namespace Fiap.Hackatoon.Product.Consumer.Tests.Shared.Fixtures;

public sealed class StateDDDFixtures : BaseFixtures<StateDDD>
{
    public StateDDDFixtures() : base() { }

    public static StateDDD GenerateStateDDD()
    {
        var faker = Faker
            .RuleFor(u => u.DDD, f => f.Random.Int(10, 99))
            .RuleFor(u => u.State, f => f.Address.State());

        return faker.Generate();
    }

    public static StateDDD CreateAs_Base()
    {
        var stateDDD = GenerateStateDDD();

        return stateDDD;
    }

    public static List<StateDDD> GenerateAllStateDDD()
    {
        var stateDDD = new List<StateDDD>
        {
            new () { DDD = 11, State = "São Paulo", Region = "Sudeste" },
            new () { DDD = 12, State = "São Paulo", Region = "Sudeste" },
            new () { DDD = 13, State = "São Paulo", Region = "Sudeste" },
            new () { DDD = 14, State = "São Paulo", Region = "Sudeste" },
            new () { DDD = 15, State = "São Paulo", Region = "Sudeste" },
            new () { DDD = 16, State = "São Paulo", Region = "Sudeste" },
            new () { DDD = 17, State = "São Paulo", Region = "Sudeste" },
            new () { DDD = 18, State = "São Paulo", Region = "Sudeste" },
            new () { DDD = 19, State = "São Paulo", Region = "Sudeste" },
            new () { DDD = 21, State = "Rio de Janeiro", Region = "Sudeste" },
            new () { DDD = 22, State = "Rio de Janeiro", Region = "Sudeste" },
            new () { DDD = 24, State = "Rio de Janeiro", Region = "Sudeste" },
            new () { DDD = 27, State = "Espírito Santo", Region = "Sudeste" },
            new () { DDD = 28, State = "Espírito Santo", Region = "Sudeste" },
            new () { DDD = 31, State = "Minas Gerais", Region = "Sudeste" },
            new () { DDD = 32, State = "Minas Gerais", Region = "Sudeste" },
            new () { DDD = 33, State = "Minas Gerais", Region = "Sudeste" },
            new () { DDD = 34, State = "Minas Gerais", Region = "Sudeste" },
            new () { DDD = 35, State = "Minas Gerais", Region = "Sudeste" },
            new () { DDD = 37, State = "Minas Gerais", Region = "Sudeste" },
            new () { DDD = 38, State = "Minas Gerais", Region = "Sudeste" },
            new () { DDD = 41, State = "Paraná", Region = "Sul" },
            new () { DDD = 42, State = "Paraná", Region = "Sul" },
            new () { DDD = 43, State = "Paraná", Region = "Sul" },
            new () { DDD = 44, State = "Paraná", Region = "Sul" },
            new () { DDD = 45, State = "Paraná", Region = "Sul" },
            new () { DDD = 46, State = "Paraná", Region = "Sul" },
            new () { DDD = 47, State = "Santa Catarina", Region = "Sul" },
            new () { DDD = 48, State = "Santa Catarina", Region = "Sul" },
            new () { DDD = 49, State = "Santa Catarina", Region = "Sul" },
            new () { DDD = 51, State = "Rio Grande do Sul", Region = "Sul" },
            new () { DDD = 53, State = "Rio Grande do Sul", Region = "Sul" },
            new () { DDD = 54, State = "Rio Grande do Sul", Region = "Sul" },
            new () { DDD = 55, State = "Rio Grande do Sul", Region = "Sul" },
            new () { DDD = 61, State = "Distrito Federal", Region = "Centro-Oeste" },
            new () { DDD = 62, State = "Goiás", Region = "Centro-Oeste" },
            new () { DDD = 63, State = "Tocantins", Region = "Centro-Oeste" },
            new () { DDD = 64, State = "Goiás", Region = "Centro-Oeste" },
            new () { DDD = 65, State = "Mato Grosso", Region = "Centro-Oeste" },
            new () { DDD = 66, State = "Mato Grosso", Region = "Centro-Oeste" },
            new () { DDD = 67, State = "Mato Grosso do Sul", Region = "Centro-Oeste" },
            new () { DDD = 68, State = "Acre", Region = "Norte" },
            new () { DDD = 69, State = "Rondônia", Region = "Norte" },
            new () { DDD = 71, State = "Bahia", Region = "Nordeste" },
            new () { DDD = 73, State = "Bahia", Region = "Nordeste" },
            new () { DDD = 74, State = "Bahia", Region = "Nordeste" },
            new () { DDD = 75, State = "Bahia", Region = "Nordeste" },
            new () { DDD = 77, State = "Bahia", Region = "Nordeste" },
            new () { DDD = 79, State = "Sergipe", Region = "Nordeste" },
            new () { DDD = 81, State = "Pernambuco", Region = "Nordeste" },
            new () { DDD = 82, State = "Alagoas", Region = "Nordeste" },
            new () { DDD = 83, State = "Paraíba", Region = "Nordeste" },
            new () { DDD = 84, State = "Rio Grande do Norte", Region = "Nordeste" },
            new () { DDD = 85, State = "Ceará", Region = "Nordeste" },
            new () { DDD = 86, State = "Piauí", Region = "Nordeste" },
            new () { DDD = 87, State = "Pernambuco", Region = "Nordeste" },
            new () { DDD = 88, State = "Ceará", Region = "Nordeste" },
            new () { DDD = 89, State = "Piauí", Region = "Nordeste" },
            new () { DDD = 91, State = "Pará", Region = "Norte" },
            new () { DDD = 93, State = "Pará", Region = "Norte" },
            new () { DDD = 94, State = "Pará", Region = "Norte" },
            new () { DDD = 95, State = "Amapá", Region = "Norte" },
            new () { DDD = 96, State = "Amapá", Region = "Norte" },
            new () { DDD = 97, State = "Amazonas", Region = "Norte" },
            new () { DDD = 98, State = "Maranhão", Region = "Nordeste" },
            new () { DDD = 99, State = "Maranhão", Region = "Nordeste" }
        };

        return stateDDD;
    }
}