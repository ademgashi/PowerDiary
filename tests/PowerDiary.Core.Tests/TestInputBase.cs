namespace PowerDiary.Core.Tests
{
    public class TestInputBase
    {
        private string? _name;

        public string? Name
        {
            get =>
                // test names must be unique within one test class
                _name + "    from " + GetType().Name;
            set => _name = value;
        }
        public override string? ToString() => Name ?? base.ToString();
        public bool ExpectSuccess { get; set; }
    }
}
