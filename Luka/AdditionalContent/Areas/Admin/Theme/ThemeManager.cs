using System;
using System.Collections.Generic;
using System.Linq;
//using Argosy.BusinessLogic.FrontEnd.Impl;
//using Argosy.BusinessLogic.V5;
//using Argosy.Common.Attributes;
using Argosy.Common.Contracts.Contract;
//using Argosy.Common.Contracts.Core.Enum;
using Argosy.Common.Contracts.Core.Interfaces;
//using Argosy.Common.Enums;
//using Argosy.Common.Interfaces;
using ArgosyModel;
//using Cerqa.Common.V5;
//using Cerqa.Common.V5.ArgosyFile;
//using ServiceStack.DataAnnotations;
using Argosy.BusinessLogic.FrontEnd.Security;
using Argosy.Common.Interfaces;
using Cerqa.Common.V5;
using Argosy.Common.Attributes;
//using Cerqa.Common.V5.ArgosyFile;
//using Argosy.BusinessLogic.V5;

namespace Argosy.BusinessLogic.FrontEnd.Managers
{
    public partial class ThemeManager
    {
        public class ThemesViewModel
        {
            public string CurrentThemeName;
            public int CurrentThemeId;
            public List<ThemeGrouping> ThemeGroupings;
        }

        public new MethodStatus<Theme> Create(Theme theme)
        {
            var status = new MethodStatus<Theme>();
            try
            {
                var themeOptionManagerList = new List<ESM_THEME_OPTION>();
                var companyId = FrontEndSession.Instance.CompanyId.GetValueOrDefault(0);
                var siteId = FrontEndSession.Instance.SiteId.GetValueOrDefault(0);
                var sessionThemeId = 1;
                var companyThemeId = 1;
                var esmTheme = new ESM_THEME
                {
                    GROUP_NAME = "Created Themes",
                    IS_DEFAULT = false,
                    IS_SYSTEM = false,
                    DATE_CREATED = DateTime.Now,
                    COMPANY_ID = 1,
                    SITE_ID = 1,
                    THEME_STRUCTURE_ID = theme.ThemeStructureId,
                    HREF = theme.Href,
                    NAME = theme.Name,
                    STYLESHEET = theme.StyleSheet,
                    PRIMARY_COLOR = theme.PrimaryColor,
                    SECONDARY_COLOR = theme.SecondaryColor,
                    TERTIARY_COLOR = theme.TertiaryColor

                };

                foreach (var themeStyle in theme.ThemeStyles)
                {
                    var esmThemeStyle = new ESM_THEME_STYLE
                    {
                        THEME_ID = esmTheme.THEME_ID,
                        THEME_GROUP_ID = themeStyle.ThemeGroupId,
                        DISPLAY_NAME = themeStyle.DisplayName,
                        NAME = themeStyle.Name,
                        SELECTOR = themeStyle.Selector,
                        ROLE = themeStyle.Role,
                        IS_PRIMARY = themeStyle.IsPrimary,
                        IS_SECONDARY = themeStyle.IsSecondary,
                        IS_TERTIARY = themeStyle.IsTertiary
                    };
                    if (themeStyle.DisplayName.Equals("Body Background Image") && !themeStyle.Value.Equals("none"))
                    {
                        //var backgroundImageValue = themeStyle.Value.Replace("url(", string.Empty).Replace(")", string.Empty);
                        var backgroundImageUrl = "";
                        //var backgroundImageUrl = GetBackgroundImageUrl(backgroundImageValue);
                        esmThemeStyle.VALUE = string.IsNullOrEmpty(backgroundImageUrl)
                                                ? "none"
                                                : $"url({backgroundImageUrl})";
                    }
                    else
                    {
                        esmThemeStyle.VALUE = themeStyle.Value;
                    }

                    if (themeStyle.ThemeOptions == null) continue;
                    foreach (var themeOption in themeStyle.ThemeOptions)
                    {
                        themeOptionManagerList.Add(new ESM_THEME_OPTION
                        {
                            THEME_STYLE_ID = esmThemeStyle.THEME_STYLE_ID,
                            VALUE = themeOption.Value,
                            TEXT = themeOption.Text,
                            IS_SELECTED = themeOption.IsSelected
                        });
                    }
                }
                theme.IsDeletable = companyThemeId != theme.Id && sessionThemeId != theme.Id && !theme.IsSystem;
                status.Data = theme;
            }
            catch (Exception err)
            {
                status.ErrorType = ErrorType.Unhandled;
                status.IsError = true;
                status.MessageSeverity = MessageSeverity.Error;
            }
            return status;
        }

        public new MethodStatus<Theme> Update(Theme theme)
        {
            var status = new MethodStatus<Theme>();
            try
            {
                //var themeManager = new ArgosyManager<ESM_THEME>();
                //var themeOptionManager = new ArgosyManager<ESM_THEME_OPTION>();
                //var themeStyleManager = new ArgosyManager<ESM_THEME_STYLE>();
                var companyId = FrontEndSession.Instance.CompanyId.GetValueOrDefault(0);
                var sessionThemeId = 1;
                var companyThemeId = 1;
                //themeManager.Update(t =>
                //{
                //    t.HREF = theme.Href;
                //    t.NAME = theme.Name;
                //    t.PRIMARY_COLOR = theme.PrimaryColor;
                //    t.SECONDARY_COLOR = theme.SecondaryColor;
                //    t.TERTIARY_COLOR = theme.TertiaryColor;
                //    t.STYLESHEET = theme.StyleSheet;
                //}, t => t.THEME_ID == theme.Id);
                //themeManager.SaveChanges();

                foreach (var themeStyle in theme.ThemeStyles)
                {
                    //themeStyleManager.Update(ts =>
                    //{
                    //    ts.DISPLAY_NAME = themeStyle.DisplayName;
                    //    ts.NAME = themeStyle.Name;
                    //    ts.VALUE = themeStyle.Value;
                    //    ts.SELECTOR = themeStyle.Selector;
                    //    ts.ROLE = themeStyle.Role;
                    //    ts.IS_PRIMARY = themeStyle.IsPrimary;
                    //    ts.IS_SECONDARY = themeStyle.IsSecondary;
                    //    ts.IS_TERTIARY = themeStyle.IsTertiary;
                    //}, ts => ts.THEME_STYLE_ID == themeStyle.ThemeStyleId);
                    //themeStyleManager.SaveChanges();

                    if (themeStyle.ThemeOptions == null) continue;
                    foreach (var themeOption in themeStyle.ThemeOptions)
                    {
                        //themeOptionManager.Update(to =>
                        //{
                        //    to.VALUE = themeOption.Value;
                        //    to.TEXT = themeOption.Text;
                        //    to.IS_SELECTED = themeOption.IsSelected;
                        //}, to => to.THEME_OPTION_ID == themeOption.ThemeOptionId);
                        //themeOptionManager.SaveChanges();
                    }
                }
                theme.IsDeletable = companyThemeId != theme.Id && sessionThemeId != theme.Id && !theme.IsSystem;
                status.Data = theme;
            }
            catch (Exception err)
            {
                //status.ErrorCode = Cerqa.Common.V5.ErrorHandling.ErrorHandlingRepositoryFactory.Instance.HandleError(err, "Update " + TypeName + " Exception", theme);
                status.ErrorType = ErrorType.Unhandled;
                status.IsError = true;
                status.MessageSeverity = MessageSeverity.Error;
                status.Message = "There was an error updating your " + "nesto" + ".  Please contact support.";
            }
            return status;
        }

        public new MethodStatus<Theme> Delete(Theme theme)
        {
            var status = new MethodStatus<Theme>();
            var company = new ESM_COMPANY() { COMPANY_ID = 1,THEME_ID = 1};
            if (!theme.IsDeletable)
            {
                if (company != null && company.THEME_ID == theme.Id)
                {
                    status.Message = "~{msgStandardThemesCanNotBeDeleted}~";
                    status.IsError = true;
                    return status;
                }
                if (theme.IsSystem)
                {
                    status.Message = "~{msgStandardThemesCanNotBeDeleted}~";
                    status.IsError = true;
                    return status;
                }
                if (int.Parse(FrontEndSession.Instance.ThemeId) == theme.Id)
                {
                    status.Message = "~{msgSessionThemeCanNotBeDeleted}~";
                    status.IsError = true;
                    return status;
                }
            }
            try
            {
                //var themeManager = new ArgosyManager<ESM_THEME>();
                //var themeStyleManager = new ArgosyManager<ESM_THEME_STYLE>();
                //var themeOptionManager = new ArgosyManager<ESM_THEME_OPTION>();

                foreach (var themeStyle in theme.ThemeStyles)
                {
                    if (themeStyle.ThemeOptions != null)
                    {
                        foreach (var themeOption in themeStyle.ThemeOptions)
                        {
                            //var esmThemeOption = themeOptionManager.FirstOrDefault(to => to.THEME_OPTION_ID == themeOption.ThemeOptionId);
                            //themeOptionManager.Delete(esmThemeOption);
                            //themeOptionManager.SaveChanges();
                        }
                    }
                    //var esmThemeStyle = themeStyleManager.FirstOrDefault(ts => ts.THEME_STYLE_ID == themeStyle.ThemeStyleId);
                    //themeStyleManager.Delete(esmThemeStyle);
                    //themeStyleManager.SaveChanges();
                }
                var esmTheme = 1;
                //themeManager.Delete(esmTheme);
                //themeManager.SaveChanges();
                status.Data = theme;
                status.IsError = false;
                status.Message = "~{msgThemeDeleted}~";
            }
            catch (Exception err)
            {
                //status.ErrorCode = Cerqa.Common.V5.ErrorHandling.ErrorHandlingRepositoryFactory.Instance.HandleError(err, "Delete " + TypeName + " Exception", theme);
                status.ErrorType = ErrorType.Unhandled;
                status.IsError = true;
                status.MessageSeverity = MessageSeverity.Error;
                status.Message = "There was an error deleting your " + "Nesto" + ".  Please contact support.";
            }
            return status;
        }
    }
    //public class ThemeManager : AbstractFrontEndManager<ThemeManager.Theme, ESM_THEME, ThemeManager.ThemeEnum, ThemeManager.ThemeSearch>
    //{
    //    public ThemeManager(bool ignoreGlobalFilters = false) : base(ignoreGlobalFilters, true) { }

    public class Theme : IObjectMap<ESM_THEME>
    {
        //[PrimaryKey]
        public int Id { get; set; }
        public int? SiteId { get; set; }
        public int? CompanyId { get; set; }
        public int? ThemeStructureId { get; set; }
        public string Name { get; set; }
        public string GroupName { get; set; }
        public string StyleSheet { get; set; }
        public string Href { get; set; }
        public string PrimaryColor { get; set; }
        public string SecondaryColor { get; set; }
        public string TertiaryColor { get; set; }
        public bool IsDefault { get; set; }
        public bool IsSystem { get; set; }
        public bool IsDeletable { get; set; }
        public DateTime DateCreated { get; set; }
        public ThemeStructure ThemeStructure { get; set; }
        public List<ThemeStyle> ThemeStyles { get; set; }

        public Theme(Theme t)
        {
            this.Id = t.Id;
            this.SiteId = t.SiteId;
            this.CompanyId = t.CompanyId;
            this.ThemeStructureId = t.ThemeStructureId;
            this.Name = t.Name;
            this.GroupName = t.GroupName;
            this.StyleSheet = t.StyleSheet;
            this.Href = t.Href;
            this.PrimaryColor = t.PrimaryColor;
            this.SecondaryColor = t.SecondaryColor;
            this.TertiaryColor = t.TertiaryColor;
            this.IsDefault = t.IsDefault;
            this.IsSystem = t.IsSystem;
            this.IsDeletable = t.IsDeletable;
            this.DateCreated = t.DateCreated;
            this.ThemeStructure = t.ThemeStructure;
            this.ThemeStyles = t.ThemeStyles;
        }
        public Theme() { }

    }

    public class ThemeStructure : IObjectMap<ESM_THEME_STRUCTURE>
    {
        //[PrimaryKey]
        public int ThemeStructureId { get; set; }
        public string Name { get; set; }
        public List<ThemeGroup> ThemeGroups { get; set; }
    }

    public class ThemeGroup : IObjectMap<ESM_THEME_GROUP>
    {
        //[PrimaryKey]
        public int ThemeGroupId { get; set; }
        public int? ThemeStructureId { get; set; }
        public int? ParentThemeGroupId { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public List<ThemeGroup> ThemeGroups { get; set; }
        public List<ThemeStyle> ThemeStyles { get; set; }
    }

    public class ThemeStyle : IObjectMap<ESM_THEME_STYLE>
    {
        //[PrimaryKey]
        public int ThemeStyleId { get; set; }
        public int ThemeGroupId { get; set; }
        public int ThemeId { get; set; }
        public string DisplayName { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Selector { get; set; }
        public string Role { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsSecondary { get; set; }
        public bool IsTertiary { get; set; }
        public List<ThemeOption> ThemeOptions { get; set; }
    }

    public class ThemeOption : IObjectMap<ESM_THEME_OPTION>
    {
        //[PrimaryKey]
        public int ThemeOptionId { get; set; }
        public int ThemeStyleId { get; set; }
        public string Value { get; set; }
        public string Text { get; set; }
        public bool IsSelected { get; set; }
    }

    //[DefaultSort("THEME_ID", "ASC")]
    //public class ThemeSearch : AbstractSearchObject<ESM_THEME>
    //    public class ThemeSearch
    //{
    //    [MappingProperty(typeof(ESM_THEME), "THEME_ID", typeof(int))]
    //    //[IgnoreProperty(IgnoreWhen.EqualToZero)]
    //    public int Id { get; set; }
    //    [MappingProperty(typeof(ESM_THEME), "SITE_ID", typeof(int?))]
    //    //[IgnoreProperty(IgnoreWhen.NullOrZero)]
    //    public int? SiteId { get; set; }
    //    [MappingProperty(typeof(ESM_THEME), "COMPANY_ID", typeof(int?))]
    //   // [IgnoreProperty(IgnoreWhen.NullOrZero)]
    //    public int? CompanyId { get; set; }
    //    [MappingProperty(typeof(ESM_THEME), "IS_SYSTEM", typeof(bool))]
    //    public bool? IsSystem { get; set; }
    //    [MappingProperty(typeof(ESM_THEME), "IS_DEFAULT", typeof(bool))]
    //    public bool? IsDefault { get; set; }
    //    [MappingProperty(typeof(ESM_THEME), "GROUP_NAME", typeof(string))]
    //    //[IgnoreProperty(IgnoreWhen.NullEmptyOrWhiteSpace)]
    //    public string GroupName { get; set; }
    //    public bool LoadCompanyAndSystemThemes { get; set; }
    //}

    //public new MethodStatus<Theme> Create(Theme theme)
    //{
    //    var status = new MethodStatus<Theme>();
    //    try
    //    {
    //        //var themeManager = new ArgosyManager<ESM_THEME>();
    //        //var themeStyleManager = new ArgosyManager<ESM_THEME_STYLE>();
    //        var themeOptionManagerList = new List<ESM_THEME_OPTION>();
    //        //var companyId = FrontEndSession.Instance.CompanyId.GetValueOrDefault(0);
    //        var companyId = FrontEndSession.Instance.CompanyId.GetValueOrDefault(0);
    //        var siteId = FrontEndSession.Instance.SiteId.GetValueOrDefault(0);
    //        //var sessionThemeId = FrontEndSession.Instance.UserSettings?.ThemeId;
    //        //var companyThemeId = new ArgosyManager<ESM_COMPANY>().FirstOrDefault(c => c.COMPANY_ID == companyId).THEME_ID;
    //        var sessionThemeId = 1;
    //        var companyThemeId = 1;
    //        var esmTheme = new ESM_THEME
    //        {
    //            GROUP_NAME = "Created Themes",
    //            IS_DEFAULT = false,
    //            IS_SYSTEM = false,
    //            DATE_CREATED = DateTime.Now,
    //            // COMPANY_ID = companyId,
    //            //SITE_ID = siteId,
    //            COMPANY_ID = 1,
    //            SITE_ID = 1,
    //            THEME_STRUCTURE_ID = theme.ThemeStructureId,
    //            HREF = theme.Href,
    //            NAME = theme.Name,
    //            STYLESHEET = theme.StyleSheet,
    //            PRIMARY_COLOR = theme.PrimaryColor,
    //            SECONDARY_COLOR = theme.SecondaryColor,
    //            TERTIARY_COLOR = theme.TertiaryColor

    //        };
    //        //themeManager.Add(esmTheme);
    //        //themeManager.SaveChanges();

    //        foreach (var themeStyle in theme.ThemeStyles)
    //        {
    //            var esmThemeStyle = new ESM_THEME_STYLE
    //            {
    //                THEME_ID = esmTheme.THEME_ID,
    //                THEME_GROUP_ID = themeStyle.ThemeGroupId,
    //                DISPLAY_NAME = themeStyle.DisplayName,
    //                NAME = themeStyle.Name,
    //                SELECTOR = themeStyle.Selector,
    //                ROLE = themeStyle.Role,
    //                IS_PRIMARY = themeStyle.IsPrimary,
    //                IS_SECONDARY = themeStyle.IsSecondary,
    //                IS_TERTIARY = themeStyle.IsTertiary
    //            };
    //            if (themeStyle.DisplayName.Equals("Body Background Image") && !themeStyle.Value.Equals("none"))
    //            {
    //                //var backgroundImageValue = themeStyle.Value.Replace("url(", string.Empty).Replace(")", string.Empty);
    //                var backgroundImageUrl = "";
    //                //var backgroundImageUrl = GetBackgroundImageUrl(backgroundImageValue);
    //                esmThemeStyle.VALUE = string.IsNullOrEmpty(backgroundImageUrl)
    //                                        ? "none"
    //                                        : $"url({backgroundImageUrl})";
    //            }
    //            else
    //            {
    //                esmThemeStyle.VALUE = themeStyle.Value;
    //            }
    //            //themeStyleManager.Add(esmThemeStyle);
    //            //themeStyleManager.SaveChanges();

    //            if (themeStyle.ThemeOptions == null) continue;
    //            foreach (var themeOption in themeStyle.ThemeOptions)
    //            {
    //                themeOptionManagerList.Add(new ESM_THEME_OPTION
    //                {
    //                    THEME_STYLE_ID = esmThemeStyle.THEME_STYLE_ID,
    //                    VALUE = themeOption.Value,
    //                    TEXT = themeOption.Text,
    //                    IS_SELECTED = themeOption.IsSelected
    //                });
    //                //themeOptionManager.SaveChanges();
    //            }
    //        }
    //        //theme = AutoMapper.Mapper.Map<ESM_THEME, Theme>(esmTheme);
    //        theme.IsDeletable = companyThemeId != theme.Id && sessionThemeId != theme.Id && !theme.IsSystem;
    //        status.Data = theme;
    //    }
    //    catch (Exception err)
    //    {
    //        //status.ErrorCode = Cerqa.Common.V5.ErrorHandling.ErrorHandlingRepositoryFactory.Instance.HandleError(err, "Create " + TypeName + " Exception", theme);
    //        status.ErrorType = ErrorType.Unhandled;
    //        status.IsError = true;
    //        status.MessageSeverity = MessageSeverity.Error;
    //        //status.Message = "There was an error creating your " + TypeName + ".  Please contact support.";
    //    }
    //    return status;
    //}

        //    public new MethodStatus<Theme> Update(Theme theme)
        //    {
        //        var status = new MethodStatus<Theme>();
        //        try
        //        {
        //            var themeManager = new ArgosyManager<ESM_THEME>();
        //            var themeOptionManager = new ArgosyManager<ESM_THEME_OPTION>();
        //            var themeStyleManager = new ArgosyManager<ESM_THEME_STYLE>();
        //            var companyId = FrontEndSession.Instance.CompanyId.GetValueOrDefault(0);
        //            var sessionThemeId = FrontEndSession.Instance.UserSettings?.ThemeId;
        //            var companyThemeId = new ArgosyManager<ESM_COMPANY>().FirstOrDefault(c => c.COMPANY_ID == companyId).THEME_ID;
        //            themeManager.Update(t =>
        //            {
        //                t.HREF = theme.Href;
        //                t.NAME = theme.Name;
        //                t.PRIMARY_COLOR = theme.PrimaryColor;
        //                t.SECONDARY_COLOR = theme.SecondaryColor;
        //                t.TERTIARY_COLOR = theme.TertiaryColor;
        //                t.STYLESHEET = theme.StyleSheet;
        //            }, t => t.THEME_ID == theme.Id);
        //            themeManager.SaveChanges();

        //            foreach (var themeStyle in theme.ThemeStyles)
        //            {
        //                themeStyleManager.Update(ts =>
        //                {
        //                    ts.DISPLAY_NAME = themeStyle.DisplayName;
        //                    ts.NAME = themeStyle.Name;
        //                    ts.VALUE = themeStyle.Value;
        //                    ts.SELECTOR = themeStyle.Selector;
        //                    ts.ROLE = themeStyle.Role;
        //                    ts.IS_PRIMARY = themeStyle.IsPrimary;
        //                    ts.IS_SECONDARY = themeStyle.IsSecondary;
        //                    ts.IS_TERTIARY = themeStyle.IsTertiary;
        //                }, ts => ts.THEME_STYLE_ID == themeStyle.ThemeStyleId);
        //                themeStyleManager.SaveChanges();

        //                if (themeStyle.ThemeOptions == null) continue;
        //                foreach (var themeOption in themeStyle.ThemeOptions)
        //                {
        //                    themeOptionManager.Update(to =>
        //                    {
        //                        to.VALUE = themeOption.Value;
        //                        to.TEXT = themeOption.Text;
        //                        to.IS_SELECTED = themeOption.IsSelected;
        //                    }, to => to.THEME_OPTION_ID == themeOption.ThemeOptionId);
        //                    themeOptionManager.SaveChanges();
        //                }
        //            }
        //            theme.IsDeletable = companyThemeId != theme.Id && sessionThemeId != theme.Id && !theme.IsSystem;
        //            status.Data = theme;
        //        }
        //        catch (Exception err)
        //        {
        //            status.ErrorCode = Cerqa.Common.V5.ErrorHandling.ErrorHandlingRepositoryFactory.Instance.HandleError(err, "Update " + TypeName + " Exception", theme);
        //            status.ErrorType = ErrorType.Unhandled;
        //            status.IsError = true;
        //            status.MessageSeverity = MessageSeverity.Error;
        //            status.Message = "There was an error updating your " + TypeName + ".  Please contact support.";
        //        }
        //        return status;
        //    }

        /// <summary>
        /// Izmenjeni create
        /// </summary>
        //public new MethodStatus<Theme> Create(Theme theme)
        //{
        //    var status = new MethodStatus<Theme>();
        //    try
        //    {
        //        var companyId = 1;
        //        var siteId = 1;
        //        var sessionThemeId = 1;
        //        var companyThemeId = 1;
        //        var esmTheme = new ESM_THEME
        //        {
        //            GROUP_NAME = "Created Themes",
        //            IS_DEFAULT = false,
        //            IS_SYSTEM = false,
        //            DATE_CREATED = DateTime.Now,
        //            //COMPANY_ID = companyId,
        //            //SITE_ID = siteId,
        //            COMPANY_ID = 1,
        //            SITE_ID = 1,
        //            THEME_STRUCTURE_ID = theme.ThemeStructureId,
        //            HREF = theme.Href,
        //            NAME = theme.Name,
        //            STYLESHEET = theme.StyleSheet,
        //            PRIMARY_COLOR = theme.PrimaryColor,
        //            SECONDARY_COLOR = theme.SecondaryColor,
        //            TERTIARY_COLOR = theme.TertiaryColor
        //        };

        //        foreach (var themeStyle in theme.ThemeStyles)
        //        {
        //            var esmThemeStyle = new ESM_THEME_STYLE
        //            {
        //                THEME_ID = esmTheme.THEME_ID,
        //                THEME_GROUP_ID = themeStyle.ThemeGroupId,
        //                DISPLAY_NAME = themeStyle.DisplayName,
        //                NAME = themeStyle.Name,
        //                SELECTOR = themeStyle.Selector,
        //                ROLE = themeStyle.Role,
        //                IS_PRIMARY = themeStyle.IsPrimary,
        //                IS_SECONDARY = themeStyle.IsSecondary,
        //                IS_TERTIARY = themeStyle.IsTertiary
        //            };
        //            if (themeStyle.DisplayName.Equals("Body Background Image") && !themeStyle.Value.Equals("none"))
        //            {
        //                var backgroundImageValue = themeStyle.Value.Replace("url(", string.Empty).Replace(")", string.Empty);
        //                //var backgroundImageUrl = GetBackgroundImageUrl(backgroundImageValue);
        //                var backgroundImageUrl = "http://www.duosasinos.com/images/duos-asinos.png";
        //                esmThemeStyle.VALUE = string.IsNullOrEmpty(backgroundImageUrl)
        //                                        ? "none"
        //                                        : $"url({backgroundImageUrl})";
        //            }
        //            else
        //            {
        //                esmThemeStyle.VALUE = themeStyle.Value;
        //            }

        //            if (themeStyle.ThemeOptions == null) continue;
        //            //foreach (var themeOption in themeStyle.ThemeOptions)
        //            //{
        //            //    themeOptionManager.Add(new ESM_THEME_OPTION
        //            //    {
        //            //        THEME_STYLE_ID = esmThemeStyle.THEME_STYLE_ID,
        //            //        VALUE = themeOption.Value,
        //            //        TEXT = themeOption.Text,
        //            //        IS_SELECTED = themeOption.IsSelected
        //            //    });
        //            //}zakomentiro
        //        }
        //       // theme = AutoMapper.Mapper.Map<ESM_THEME, Theme>(esmTheme);zakomentro
        //        theme.IsDeletable = companyThemeId != theme.Id && sessionThemeId != theme.Id && !theme.IsSystem;
        //        status.Data = theme;
        //    }
        //    catch (Exception err)
        //    {
        //       // status.ErrorCode = Cerqa.Common.V5.ErrorHandling.ErrorHandlingRepositoryFactory.Instance.HandleError(err, "Create " + TypeName + " Exception", theme);
        //        status.ErrorType = ErrorType.Unhandled;
        //        status.IsError = true;
        //        status.MessageSeverity = MessageSeverity.Error;
        //       // status.Message = "There was an error creating your " + TypeName + ".  Please contact support.";
        //    }
        //    return status;
        //}



        //    public new MethodStatus<Theme> Delete(Theme theme)
        //    {
        //        var status = new MethodStatus<Theme>();
        //        var company = new ArgosyManager<ESM_COMPANY>().FirstOrDefault(c => c.COMPANY_ID == theme.CompanyId);
        //        if (!theme.IsDeletable)
        //        {
        //            if (company != null && company.THEME_ID == theme.Id)
        //            {
        //                status.Message = "~{msgStandardThemesCanNotBeDeleted}~";
        //                status.IsError = true;
        //                return status;
        //            }
        //            if (theme.IsSystem)
        //            {
        //                status.Message = "~{msgStandardThemesCanNotBeDeleted}~";
        //                status.IsError = true;
        //                return status;
        //            }
        //            if (int.Parse(FrontEndSession.Instance.ThemeId) == theme.Id)
        //            {
        //                status.Message = "~{msgSessionThemeCanNotBeDeleted}~";
        //                status.IsError = true;
        //                return status;
        //            }
        //        }
        //        try
        //        {
        //            var themeManager = new ArgosyManager<ESM_THEME>();
        //            var themeStyleManager = new ArgosyManager<ESM_THEME_STYLE>();
        //            var themeOptionManager = new ArgosyManager<ESM_THEME_OPTION>();

        //            foreach (var themeStyle in theme.ThemeStyles)
        //            {
        //                if (themeStyle.ThemeOptions != null)
        //                {
        //                    foreach (var themeOption in themeStyle.ThemeOptions)
        //                    {
        //                        var esmThemeOption = themeOptionManager.FirstOrDefault(to => to.THEME_OPTION_ID == themeOption.ThemeOptionId);
        //                        themeOptionManager.Delete(esmThemeOption);
        //                        themeOptionManager.SaveChanges();
        //                    }
        //                }
        //                var esmThemeStyle = themeStyleManager.FirstOrDefault(ts => ts.THEME_STYLE_ID == themeStyle.ThemeStyleId);
        //                themeStyleManager.Delete(esmThemeStyle);
        //                themeStyleManager.SaveChanges();
        //            }
        //            var esmTheme = themeManager.FirstOrDefault(t => t.THEME_ID == theme.Id);
        //            themeManager.Delete(esmTheme);
        //            themeManager.SaveChanges();
        //            status.Data = theme;
        //            status.IsError = false;
        //            status.Message = "~{msgThemeDeleted}~";
        //        }
        //        catch (Exception err)
        //        {
        //            status.ErrorCode = Cerqa.Common.V5.ErrorHandling.ErrorHandlingRepositoryFactory.Instance.HandleError(err, "Delete " + TypeName + " Exception", theme);
        //            status.ErrorType = ErrorType.Unhandled;
        //            status.IsError = true;
        //            status.MessageSeverity = MessageSeverity.Error;
        //            status.Message = "There was an error deleting your " + TypeName + ".  Please contact support.";
        //        }
        //        return status;
        //    }

        //private static string GetBackgroundImageUrl(string backgroundImageUrl)
        //{
        //    if (string.IsNullOrEmpty(backgroundImageUrl)) return string.Empty;
        //    var backgroundImageFile = FileFactory.GetInstance(new Uri(backgroundImageUrl));
        //    var backgroundImageUploadFileLocation = FileFactory.GetInstance(FileLocations.CustomerLogo, backgroundImageFile.Name, null, FrontEndSession.Instance.CompanyId);
        //    backgroundImageFile.CopyTo(backgroundImageUploadFileLocation);
        //    backgroundImageUrl = backgroundImageUploadFileLocation.Uri.AbsoluteUri;
        //    return backgroundImageUrl;
        //}

        //public static ThemesViewModel GetViewModel()
        //{
        //    var companyId = FrontEndSession.Instance.CompanyId.GetValueOrDefault(0);
        //    var sessionThemeId = FrontEndSession.Instance.UserSettings?.ThemeId;
        //    var result = new ThemesViewModel();
        //    var themes = new ArgosyManager<ESM_THEME>().Find(x => x.IS_SYSTEM || x.COMPANY_ID == companyId).ToList();
        //    if (!themes.Any()) return result;
        //    {
        //        result = AutoMapper.Mapper.Map<List<ESM_THEME>, ThemesViewModel>(themes);
        //        var currentThemeInfo = sessionThemeId != null
        //            ? themes.FirstOrDefault(x => x.THEME_ID == sessionThemeId)
        //            : themes.FirstOrDefault(x => x.THEME_ID == 1);
        //        if (currentThemeInfo != null)
        //        {
        //            SetThemeIdAndName(currentThemeInfo, result);
        //        }
        //    }
        //    return result;
        //}

        //private static void SetThemeIdAndName(ESM_THEME currentThemeInfo, ThemesViewModel result)
        //{
        //    if (currentThemeInfo == null) return;

        //    result.CurrentThemeId = currentThemeInfo.THEME_ID;
        //    result.CurrentThemeName = currentThemeInfo.NAME;
        //}

        //public class ThemesViewModel
        //{
        //    public string CurrentThemeName;
        //    public int CurrentThemeId;
        //    public List<ThemeGrouping> ThemeGroupings;
        //}

    public class ThemeGrouping
        {
            public string Name;
            public List<ThemeInfo> ThemeInfoList;
            public ThemeGrouping(string name, List<ThemeInfo> themeInfoList)
            {
                Name = name;
                ThemeInfoList = themeInfoList;
            }
        }

        public class ThemeInfo
        {
            public string Name;
            public int ThemeId;
            public string PrimaryColor;
            public string SecondaryColor;
            public string TertiaryColor;
            public bool IsDefault;
            public bool IsSystem;
        }

        public enum ThemeEnum
        {

        }

        //protected override List<Theme> MapData(ThemeSearch search, IQueryable<ESM_THEME> results)
        //{
        //    return BaseMapData(search, results);
        //}

        //public static PagedClientResponse<Theme> GetThemes(int siteId, int companyId)
        //{
        //    var manager = new ThemeManager();
        //    var search = new ThemeSearch()
        //    {
        //        CompanyId = companyId,
        //        SiteId = siteId,
        //        Skip = 0,
        //        Take = int.MaxValue
        //    };
        //    var results = manager.Search(search);
        //    return results;
        //}

        //public static string GetSiteIcon(int siteId, int companyId, string defaultIcon)
        //{
        //    var manager = new ArgosyManager<ESM_SITE>();
        //    var imageFile = "";
        //    IFileInfo file = null;
        //    if (manager.Any(a => a.SITE_ID == siteId && a.FLAG_ALLOW_COMPANY_WHITE_LABEL))
        //    {
        //        imageFile = new ArgosyManager<ESM_COMPANY>().FirstOrDefault(a => a.COMPANY_ID == companyId)?.WHITE_LABEL_SITE_ICON;
        //        if (!string.IsNullOrWhiteSpace(imageFile))
        //        {
        //            file = FileFactory.GetInstance(FileLocations.CustomerLogo, imageFile, null, companyId);
        //        }
        //    }
        //    if (string.IsNullOrWhiteSpace(imageFile))
        //    {
        //        imageFile = manager.FirstOrDefault(a => a.SITE_ID == siteId)?.FAVORITE_ICON_FILE;
        //        if (!string.IsNullOrWhiteSpace(imageFile))
        //        {
        //            file = FileFactory.GetInstance(FileLocations.SiteLogo, imageFile, siteId);
        //        }
        //    }
        //    if (file != null)
        //    {
        //        imageFile = file.Uri.AbsolutePath;
        //    }
        //    return imageFile ?? defaultIcon;
        //}

        //public static string GetLoadingImage(int siteId, int companyId, string defaultImage)
        //{
        //    var manager = new ArgosyManager<ESM_SITE>();
        //    var imageFile = "";
        //    IFileInfo file = null;
        //    if (manager.Any(a => a.SITE_ID == siteId && a.FLAG_ALLOW_COMPANY_WHITE_LABEL))
        //    {
        //        imageFile = new ArgosyManager<ESM_COMPANY>().FirstOrDefault(a => a.COMPANY_ID == companyId)?.WHITE_LABEL_LOADING_IMAGE;
        //        if (!string.IsNullOrWhiteSpace(imageFile))
        //        {
        //            file = FileFactory.GetInstance(FileLocations.CustomerLogo, imageFile, null, companyId);
        //        }
        //    }
        //    if (string.IsNullOrWhiteSpace(imageFile))
        //    {
        //        imageFile = manager.FirstOrDefault(a => a.SITE_ID == siteId)?.LOADING_IMAGE_FILE;
        //        if (!string.IsNullOrWhiteSpace(imageFile))
        //        {
        //            file = FileFactory.GetInstance(FileLocations.SiteLogo, imageFile, siteId);
        //        }
        //    }
        //    if (file != null)
        //    {
        //        imageFile = file.Uri.AbsolutePath;
        //    }
        //    return imageFile ?? defaultImage;
        //}
    //}
}
