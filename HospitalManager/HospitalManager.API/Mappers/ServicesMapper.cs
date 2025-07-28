namespace HospitalManager.API.Mappers
{
    public static class ServicesMapper
    {
        public static Models.ServicesMod SBllToApi(this BLL.Models.ServicesMod service)
        {
            return new Models.ServicesMod()
            {
                Id = service.Id,
                Name = service.Name
            };
        }
    }
}
