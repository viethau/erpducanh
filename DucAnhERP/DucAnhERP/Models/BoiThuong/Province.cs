﻿namespace DucAnhERP.Models.BoiThuong
{
    public class Province
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<District> Districts { get; set; } = new();
    }

}
