using System;
using Delux.Data.Treatment;
using Delux.Domain.Technician;
using Delux.Domain.Treatment;
using Delux.Facade.Treatment;
using Delux.Pages.Common;

namespace Delux.Pages.Treatment
{
    public class HairTreatmentsPage : CommonPage<IHairTreatmentsRepository, HairTreatment, HairTreatmentView, HairTreatmentData>
    {
        //protected internal readonly IHairdressersRepository hairdressers;
        //public IList<HairdresserView> Hairdressers { get; }
       
        protected internal HairTreatmentsPage(IHairTreatmentsRepository r, IHairdressersRepository h) : base(r)
        {
            PageTitle = "Hair Treatments";
            //Hairdressers=new List<HairdresserView>();
            //hairdressers =h;
        }

        public override string ItemId => throw new NotImplementedException();

        //Pihol oli nii: public override string ItemId => Item?.Id ?? string.Empty;

        protected internal override string GetPageUrl() => "/Treatment/HairTreatments";

        protected internal override HairTreatment ToObject(HairTreatmentView view) => HairTreatmentViewFactory.Create(view);

        protected internal override HairTreatmentView ToView(HairTreatment obj) => HairTreatmentViewFactory.Create(obj);

        //public void LoadDetails(HairTreatmentView item)
        //{
        //    Hairdressers.Clear();

        //    if (item is null) return;
        //    hairdressers.FixedFilter = GetMember.Name<HairdresserData>(x => x.MasterId);
        //    hairdressers.FixedValue = item.Name; //Pihol oli siin Id
        //    var list = hairdressers.Get().GetAwaiter().GetResult();

        //    foreach (var e in list)
        //    {
        //        Hairdressers.Add(HairdresserViewFactory.Create(e));
        //    }
        //}
    }
}
