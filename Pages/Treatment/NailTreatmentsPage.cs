using System;
using Delux.Data.Treatment;
using Delux.Domain.Technician;
using Delux.Domain.Treatment;
using Delux.Facade.Treatment;
using Delux.Pages.Common;

namespace Delux.Pages.Treatment
{
    public class NailTreatmentsPage : CommonPage<INailTreatmentsRepository, NailTreatment, NailTreatmentView, NailTreatmentData>
    {
        //protected internal readonly INailTechniciansRepository nailTechnicians;
        //public IList<NailTechnicianView> NailTechnicians { get; }
        
        protected internal NailTreatmentsPage(INailTreatmentsRepository r, INailTechniciansRepository n) : base(r)
        {
            PageTitle = "Nail Treatments";
            //NailTechnicians = new List<NailTechnicianView>();
            //nailTechnicians = n;
        }

        public override string ItemId => throw new NotImplementedException();

        //Pihol oli nii: public override string ItemId => Item?.Id ?? string.Empty;

        protected internal override string GetPageUrl() => "/Treatment/NailTreatments";

        protected internal override NailTreatment ToObject(NailTreatmentView view) => NailTreatmentViewFactory.Create(view);

        protected internal override NailTreatmentView ToView(NailTreatment obj) => NailTreatmentViewFactory.Create(obj);

        //public void LoadDetails(NailTreatmentView item)
        //{
        //    NailTechnicians.Clear();

        //    if (item is null) return;
        //    nailTechnicians.FixedFilter = GetMember.Name<NailTechnicianData>(x => x.MasterId);
        //    nailTechnicians.FixedValue = item.Name; //Pihol oli siin Id
        //    var list = nailTechnicians.Get().GetAwaiter().GetResult();

        //    foreach (var e in list)
        //    {
        //        NailTechnicians.Add(NailTechnicianViewFactory.Create(e));
        //    }
        //}
    }
}
