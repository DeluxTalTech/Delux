using System;
using System.Collections.Generic;
using Delux.Aids;
using Delux.Data.Technician;
using Delux.Data.Treatment;
using Delux.Domain.Technician;
using Delux.Domain.Treatment;
using Delux.Facade.Technician;
using Delux.Facade.Treatment;
using Delux.Pages.Common;

namespace Delux.Pages.Treatment
{
    public class MassageTreatmentsPage : CommonPage<IMassageTreatmentsRepository, MassageTreatment, MassageTreatmentView, MassageTreatmentData>
    {
        //protected internal readonly IMasseusesRepository masseuses;
        //public IList<MasseuseView> Masseuses { get; }
       
        protected internal MassageTreatmentsPage(IMassageTreatmentsRepository r, IMasseusesRepository m) : base(r)
        {
            PageTitle = "Massage Treatments";
            //Masseuses = new List<MasseuseView>();
            //masseuses = m;
        }

        public override string ItemId => throw new NotImplementedException();

        //Pihol oli nii: public override string ItemId => Item?.Id ?? string.Empty;

        protected internal override string GetPageUrl() => "/Treatment/MassageTreatments";

        protected internal override MassageTreatment ToObject(MassageTreatmentView view) => MassageTreatmentViewFactory.Create(view);

        protected internal override MassageTreatmentView ToView(MassageTreatment obj) => MassageTreatmentViewFactory.Create(obj);

        //public void LoadDetails(MassageTreatmentView item)
        //{
        //    Masseuses.Clear();

        //    if (item is null) return;
        //    masseuses.FixedFilter = GetMember.Name<MasseuseData>(x => x.MasterId);
        //    masseuses.FixedValue = item.Name; //Pihol oli siin Id
        //    var list = masseuses.Get().GetAwaiter().GetResult();

        //    foreach (var e in list)
        //    {
        //        Masseuses.Add(MasseuseViewFactory.Create(e));
        //    }
        //}
    }
}
