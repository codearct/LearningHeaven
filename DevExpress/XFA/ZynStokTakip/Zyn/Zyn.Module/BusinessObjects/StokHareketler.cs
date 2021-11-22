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
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class StokHareketler : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public StokHareketler(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        double tutar;
        double kdvTutar;
        double netTutar;
        double birimFiyat;
        double miktar;
        string birim;
        Stoklar stokId;
        Siparisler siparisId;

        [XafDisplayName("Sipariş")]
        [Association("Siparisler-Hareket")]
        public Siparisler SiparisId
        {
            get => siparisId;
            set
            {
                Siparisler eskiSiparis = siparisId;
                bool modified = SetPropertyValue(nameof(SiparisId), ref siparisId, value);
                if (!IsLoading && !IsSaving && eskiSiparis != siparisId && modified)
                {
                    eskiSiparis = eskiSiparis ?? siparisId;
                    eskiSiparis.UpdateAltToplam(true);
                    eskiSiparis.UpdateKdvToplam(true);
                    eskiSiparis.UpdateGenelToplam(true);
                }
            }
        }
        public Stoklar StokId
        {
            get => stokId;
            set
            {
                SetPropertyValue(nameof(StokId), ref stokId, value);
                BirimFiyat = stokId.SatisFiyati;
            }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Birim
        {
            get => birim;
            set => SetPropertyValue(nameof(Birim), ref birim, value);
        }

        public double Miktar
        {
            get => miktar;
            set => SetPropertyValue(nameof(Miktar), ref miktar, value);
        }

        public double BirimFiyat
        {
            get => birimFiyat;
            set => SetPropertyValue(nameof(BirimFiyat), ref birimFiyat, value);
        }

        public double NetTutar
        {
            get => netTutar;
            set
            {
                bool modified = SetPropertyValue(nameof(NetTutar), ref netTutar, value);
                if(!IsLoading && !IsSaving && SiparisId != null && modified)
                {
                    SiparisId.UpdateAltToplam(true);
                } 
                    
            }
        }

        public double KdvTutar
        {
            get => kdvTutar;
            set
            {
                bool modified= SetPropertyValue(nameof(KdvTutar), ref kdvTutar, value);
                if (!IsLoading && !IsSaving && SiparisId != null && modified)
                {
                    SiparisId.UpdateKdvToplam(true);
                }
            }
        }
        
        public double Tutar
        {
            get => tutar;
            set
            {
                bool modified= SetPropertyValue(nameof(Tutar), ref tutar, value);
                if (!IsLoading && !IsSaving && SiparisId != null && modified)
                {
                    SiparisId.UpdateGenelToplam(true);
                }
            }
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