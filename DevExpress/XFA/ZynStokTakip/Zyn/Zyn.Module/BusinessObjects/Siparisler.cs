using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Zyn.Module.BusinessObjects
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    [DefaultProperty("Siparis")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Siparisler : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Siparisler(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            Tarih = DateTime.Now;
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        string siparis;
        double genelToplam;
        double kdvToplam;
        double altToplam;
        Kisiler cariId;
        DateTime tarih;
        string kod;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Kod
        {
            get => kod;
            set => SetPropertyValue(nameof(Kod), ref kod, value);
        }
        
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Siparis
        {
            get => siparis;
            set => SetPropertyValue(nameof(Siparis), ref siparis, value);
        }
        public DateTime Tarih
        {
            get => tarih;
            set => SetPropertyValue(nameof(Tarih), ref tarih, value);
        }

        public Kisiler CariId
        {
            get => cariId;
            set => SetPropertyValue(nameof(CariId), ref cariId, value);
        }

        public double AltToplam
        {
            get
            {
                if (!IsLoading && !IsSaving && altToplam == 0) UpdateAltToplam(false);
                return altToplam;
            }
            set => SetPropertyValue(nameof(AltToplam), ref altToplam, value);
        }

        public double KdvToplam
        {
            get
            {
                if (!IsLoading && !IsSaving && kdvToplam == 0) UpdateKdvToplam(false);
                return kdvToplam;
            }
            set => SetPropertyValue(nameof(KdvToplam), ref kdvToplam, value);
        }
        
        public double GenelToplam
        {
            get
            {
                if (!IsLoading && !IsSaving && genelToplam == 0) UpdateGenelToplam(false);
                return genelToplam;
            }
            set => SetPropertyValue(nameof(GenelToplam), ref genelToplam, value);
        }

        [Association("Siparisler-Hareket")]
        public XPCollection<StokHareketler> Hareket
        {
            get
            {
                return GetCollection<StokHareketler>(nameof(Hareket));
            }
        }
        public void UpdateAltToplam(bool ChangeEvents)
        {
            double? eskiToplam = altToplam;
            double temp = 0;
            foreach (StokHareketler item in Hareket)
            {
                temp += item.NetTutar;
            }
            altToplam = temp;
            if (ChangeEvents) OnChanged(nameof(AltToplam), eskiToplam, altToplam);
        }
        public void UpdateKdvToplam(bool ChangeEvents)
        {
            double? eskiToplam = kdvToplam;
            double temp = 0;
            foreach (StokHareketler item in Hareket)
            {
                temp += item.KdvTutar;
            }
            kdvToplam = temp;
            if (ChangeEvents) OnChanged(nameof(KdvToplam), eskiToplam, kdvToplam);
        }
        public void UpdateGenelToplam(bool ChangeEvents)
        {
            double? eskiToplam = genelToplam;
            double temp = 0;
            foreach (StokHareketler item in Hareket)
            {
                temp += item.Tutar;
            }
            genelToplam = temp;
            if (ChangeEvents) OnChanged(nameof(GenelToplam), eskiToplam, genelToplam);
        }
        private void Reset()
        {
            altToplam = 0;
            kdvToplam = 0;
            genelToplam = 0;
        }
        protected override void OnLoaded()
        {
            Reset();
            base.OnLoaded();
        }
        //private string _PersistentProperty;
        //[XafDisplayName("My display name"), ToolTip("My hint message")]
        //[ModelDefault("EditMask", "(000)-00"), Index(0), VisibleInListView(false)]
        //[Persistent("DatabaseColumnName"), RuleRequiredField(DefaultContexts.Save)]
        //public string PersistentProperty {
        //    get { return _PersistentProperty; }
        //    set { SetPropertyValue(nameof(PersistentProperty), ref _PersistentProperty, value); }
        //}

        //[Action(Caption = "My UI Action", ConfirmationMessage = "Are you sure?", ImageName = "Attention", AutoCommit = true)]
        //public void ActionMethod() {
        //    // Trigger a custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
        //    this.PersistentProperty = "Paid";
        //}
    }
}