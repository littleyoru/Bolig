using Residences.Enums;
using Residences.Implementation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Residences.Controllers
{
    public class ResidenceController
    {
        public void AddResidence(Residence r)
        {
            BoligContext bc = new BoligContext();
            var residenceRepo = new Repository<Residence>(bc);
            using (var unit = new UnitOfWork(bc))
            {
                residenceRepo.Add(r);
                unit.Commit();
            }
        }

        public ResidenceDetails GetResidence(int id)
        {
            BoligContext bc = new BoligContext();
            var resRepo = new Repository<Residence>(bc);
            var residence = resRepo.GetById(id);
            var residenceDetails = new ResidenceDetails
            {
                Id = residence.Id,
                Title = residence.Title,
                ResType = residence.ResidenceType ?? ResidenceType.None,
                Rent = residence.Rent,
                Size = residence.Size,
                Rooms = residence.Rooms,
                AllowPets = residence.AllowPets,
                Street = residence.Street,
                PostCode = residence.PostCode.Code,
                City = residence.PostCode.City,
                AvailableFrom = residence.AvailableFrom,
                RentDuration = residence.RentDuration,
                PublishDate = residence.PublishDate,
                Deposit = residence.Deposit ?? 0,
                UtilitiesCost = residence.UtilitiesCost ?? 0,
                UserId = residence.User.Id
            };

            return residenceDetails;
        }

        public List<ResidenceDetails> FilterResidences(ResidenceFilter filter)
        {
            var residences = new List<ResidenceDetails>();
            BoligContext bc = new BoligContext();
            var resRepo = new Repository<Residence>(bc);

            var tempList = filter.resType != 0 ? resRepo.Get(x => x.ResidenceType == filter.resType) : resRepo.Get();

            if (filter.minRent > 0) tempList = tempList.Where(x => x.Rent >= filter.minRent);
            if (filter.maxRent < 50000) tempList = tempList.Where(x => x.Rent <= filter.maxRent);

            if (filter.minSize != 0) tempList = tempList.Where(x => x.Size >= filter.minSize);
            if (filter.maxSize != 0) tempList = tempList.Where(x => x.Size <= filter.maxSize);

            if (filter.rooms != 0) tempList = tempList.Where(x => x.Rooms == filter.rooms);

            if (filter.allowPets != null) tempList = tempList.Where(x => x.AllowPets == filter.allowPets);

            if (filter.postCode != 0) tempList = tempList.Where(x => x.PostCode.Code == filter.postCode);

            if (filter.availableFrom != null) tempList = tempList.Where(x => x.AvailableFrom >= filter.availableFrom);

            //tempList = tempList.ToList();

            foreach(var item in tempList)
            {
                var itemDetails = new ResidenceDetails
                {
                    Id = item.Id,
                    Title = item.Title,
                    ResType = item.ResidenceType ?? ResidenceType.None,
                    Rent = item.Rent,
                    Size = item.Size,
                    Rooms = item.Rooms,
                    AllowPets = item.AllowPets,
                    Street = item.Street,
                    PostCode = item.PostCode.Code,
                    City = item.PostCode.City,
                    AvailableFrom = item.AvailableFrom,
                    RentDuration = item.RentDuration,
                    PublishDate = item.PublishDate,
                    Deposit = item.Deposit ?? 0,
                    UtilitiesCost = item.UtilitiesCost ?? 0,
                    UserId = item.User.Id
                };
                residences.Add(itemDetails);
            }

            return residences;
        }
    }

    public class ResidenceFilter
    {
        public ResidenceType resType = 0;
        public int minRent = 0;
        public int maxRent = 50000;
        public int minSize = 0;
        public int maxSize = 0;
        public byte rooms = 0;
        public bool? allowPets = null;
        public int postCode = 0;
        public DateTime? availableFrom = null;
    }

    public class ResidenceDetails
    {
        public int Id;
        public string Title;
        public ResidenceType ResType;
        public int Rent;
        public short Size;
        public byte Rooms;
        public bool? AllowPets;
        public string Street;
        public int PostCode;
        public string City;
        public DateTime? AvailableFrom;
        public int? RentDuration;
        public DateTime PublishDate;
        public int Deposit;
        public int UtilitiesCost;
        public int UserId;
    }
}
