using Ardalis.SmartEnum;
using RT.Comb;

namespace Win.UI;
internal abstract class UuidGenerator : SmartEnum<UuidGenerator> {
    public static readonly UuidGenerator Random = new RandomGenerator();
    public static readonly UuidGenerator CombTime = new CombTimeGenerator();
    public static readonly UuidGenerator CombTimeRTL = new CombTimeRTLGenerator();


    private UuidGenerator(string name, int value) : base(name, value) { }

    public abstract Guid Generate();


    private sealed class RandomGenerator : UuidGenerator {
        public RandomGenerator() : base("Random", 1) { }

        public override Guid Generate() {
            return Guid.NewGuid();
        }
    }

    private sealed class CombTimeGenerator : UuidGenerator {
        public CombTimeGenerator() : base("CombTime", 2) { }

        public override Guid Generate() {
            return Provider.PostgreSql.Create();
        }
    }

    private sealed class CombTimeRTLGenerator : UuidGenerator {
        public CombTimeRTLGenerator() : base("CombTimeRTL", 3) { }

        public override Guid Generate() {
            return Provider.Sql.Create();
        }
    }
}
