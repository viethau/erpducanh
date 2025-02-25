namespace DucAnhERP.Models.BoiThuong
{
    public class District
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Ward> Wards { get; set; } = new();
    }
}
