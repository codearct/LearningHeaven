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
    [DefaultProperty("Tanim")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Stoklar : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Stoklar(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        double satisFiyati;
        double alisFiyati;
        double satisKDV;
        double alisKDV;
        string urun;
        string kod;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Kod
        {
            get => kod;
            set => SetPropertyValue(nameof(Kod), ref kod, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Urun
        {
            get => urun;
            set => SetPropertyValue(nameof(Urun), ref urun, value);
        }

        [PersistentAlias("Concat([Kod],' - ',[Urun])")]
        public string Tanim => (string)EvaluateAlias("Tanim");
        public double AlisKDV
        {
            get => alisKDV;
            set => SetPropertyValue(nameof(AlisKDV), ref alisKDV, value);
        }

        public double SatisKDV
        {
            get => satisKDV;
            set => SetPropertyValue(nameof(SatisKDV), ref satisKDV, value);
        }

        public double AlisFiyati
        {
            get => alisFiyati;
            set => SetPropertyValue(nameof(AlisFiyati), ref alisFiyati, value);
        }
        
        public double SatisFiyati
        {
            get => satisFiyati;
            set => SetPropertyValue(nameof(SatisFiyati), ref satisFiyati, value);
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