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
    public class FacialTreatmentsPage:CommonPage<IFacialTreatmentsRepository, FacialTreatment, FacialTreatmentView,FacialTreatmentData>
    {
        //protected internal readonly IBeauticiansRepository beauticians;
        //public IList<BeauticianView> Beauticians { get; }
        protected internal FacialTreatmentsPage(IFacialTreatmentsRepository r, IBeauticiansRepository b) : base(r)
        {
            PageTitle = "Facial Treatments";
            //Beauticians=new List<BeauticianView>();
            //beauticians = b;
        }

        public override string ItemId => throw new NotImplementedException();

        //Pihol oli nii: public override string ItemId => Item?.Id ?? string.Empty;

        protected internal override string GetPageUrl() => "/Treatment/FacialTreatments";

        protected internal override FacialTreatment ToObject(FacialTreatmentView view) => FacialTreatmentViewFactory.Create(view);

        protected internal override FacialTreatmentView ToView(FacialTreatment obj) => FacialTreatmentViewFactory.Create(obj);

        //public void LoadDetails(FacialTreatmentView item)
        //{
        //    Beauticians.Clear();

        //    if (item is null) return;
        //    beauticians.FixedFilter = GetMember.Name<BeauticianData>(x => x.MasterId);
        //    beauticians.FixedValue = item.Name; //Pihol oli siin Id
        //    var list = beauticians.Get().GetAwaiter().GetResult();

        //    foreach (var e in list)
        //    {
        //        Beauticians.Add(BeauticianViewFactory.Create(e));
        //    }
        //}
    }
}
