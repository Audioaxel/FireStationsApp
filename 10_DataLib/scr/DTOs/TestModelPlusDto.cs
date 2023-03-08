namespace DataLib.DTOs;

public class TestModelPlusDto
{
    public int Id { get; set; }
    public string TestString { get; set; }
    public string TestStringPlus { get; set; }
}

public class CreateTestModelPlusDto
{
    public string TestString { get; set; }
    public string TestStringPlus { get; set; }
}