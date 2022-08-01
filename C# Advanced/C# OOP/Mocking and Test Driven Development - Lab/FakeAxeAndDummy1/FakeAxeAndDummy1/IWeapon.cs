namespace FakeAxeAndDummy1
{
    public interface IWeapon
    {
        int AttackPoints { get; }
        int DurabilityPoints { get; }
        public void Attack(ITarget target);

    }
}
