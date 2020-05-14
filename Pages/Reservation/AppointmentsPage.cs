//using Delux.Data.Reservation;
//using Delux.Domain.Reservation;
//using Delux.Facade.Reservation;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using System.Collections.Generic;
//using Delux.Aids;
//using Delux.Data.Technician;
//using Delux.Facade.Common;
//using Delux.Pages.Common;

//namespace Delux.Pages.Reservation
//{

//    public abstract class AppointmentsPage : CommonPage<IAppointmentsRepository, Appointment, AppointmentView, AppointmentData>
//    {
//        //protected internal readonly IAppointmentsRepository terms;
//        //protected internal readonly IAppointmentsRepository factors;
//        public IEnumerable<SelectListItem> Treatments { get; }
//        public IEnumerable<SelectListItem> Technicians { get; }

//        //public IList<UnitTermView> Terms { get; }
//        //public IList<UnitFactorView> Factors { get; }

//        protected internal AppointmentsPage(IAppointmentsRepository a, ITreatmentsRepository tr,
//            ITechniciansRepository t) : base(a)
//        {
//            PageTitle = "Units";
//            Treatments = createSelectList<Treatment, TreatmentData>(tr);
//            Technicians = createSelectList<Technician, TechnicianData>(te);
//            //Terms = new List<UnitTermView>();
//            //Factors = new List<UnitFactorView>();
//            //terms = t;
//            //factors = f;
//        }

//        //private static IEnumerable<SelectListItem> CreateTreatments(IMeasuresRepository r)
//        //{
//        //    var list = new List<SelectListItem>();
//        //    var measures = r.Get().GetAwaiter().GetResult();

//        //    foreach (var m in measures)
//        //    {
//        //        list.Add(new SelectListItem(m.Data.Name, m.Data.Id));
//        //    }

//        //    return list;
//        //}


//        //private static IEnumerable<SelectListItem> CreateTechnicians(IMeasuresRepository r)
//        //{
//        //    var list = new List<SelectListItem>();
//        //    var measures = r.Get().GetAwaiter().GetResult();

//        //    foreach (var m in measures)
//        //    {
//        //        list.Add(new SelectListItem(m.Data.Name, m.Data.Id));
//        //    }

//        //    return list;
//        //}


//        public override string ItemId => Item?.Id ?? string.Empty;

//        protected internal override string GetPageUrl() => "/Salon/Appointments";

//        protected internal override string GetPageSubTitle()
//        {
//            return FixedValue is null
//                ? base.GetPageSubTitle()
//                : $"For {GetTreatmentName(FixedValue)}.{GetTechnicianName(FixedValue)}";
//        }

//        protected internal override Appointment ToObject(AppointmentView view)
//        {
//            return AppointmentViewFactory.Create(view);
//        }

//        protected internal override AppointmentView ToView(Appointment obj)
//        {
//            return AppointmentViewFactory.Create(obj);
//        }
//        public string GetTreatmentName(string treatmentId)
//        {
//            foreach (var m in Treatments)
//                if (m.Value == treatmentId)
//                    return m.Text;
//            return "Unspecified";
//        }

//        public string GetTechnicianName(string technicianId)
//        {
//            foreach (var m in Technicians)
//                if (m.Value == technicianId)
//                    return m.Text;
//            return "Unspecified";
//        }

//        //public void LoadDetails(UnitView item)
//        //{
//        //    LoadTerms(item);
//        //    LoadFactors(item);
//        //}

//        //private void LoadFactors(UniqueEntityView item)
//        //{
//        //    Factors.Clear();
//        //    if (item is null) return;
//        //    factors.FixedFilter = GetMember.Name<UnitFactorData>(x => x.UnitId);
//        //    factors.FixedValue = item.Id;
//        //    var list = factors.Get().GetAwaiter().GetResult();

//        //    foreach (var e in list)
//        //    {
//        //        Factors.Add(UnitFactorViewFactory.Create(e));
//        //    }
//        //}

//        //private void LoadTerms(UniqueEntityView item)
//        //{
//        //    Terms.Clear();

//        //    if (item is null) return;
//        //    terms.FixedFilter = GetMember.Name<UnitTermData>(x => x.MasterId);
//        //    terms.FixedValue = item.Id;
//        //    var list = terms.Get().GetAwaiter().GetResult();

//        //    foreach (var e in list)
//        //    {
//        //        Terms.Add(UnitTermViewFactory.Create(e));
//        //    }

//        //}
//    }

//}