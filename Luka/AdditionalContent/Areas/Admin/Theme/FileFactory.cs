//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Globalization;
//using System.IO;
//using System.Linq;
//using System.Reflection;
//using System.Web;
//using System.Web.Hosting;
////using Argosy.Common.Config;
//using Argosy.Common.Contracts.Contract;
//using Argosy.Common.Contracts.Core.Enum;
////using Argosy.Common.Contracts.Core.Attributes;
////using Argosy.Common.Contracts.Core.Enum;
////using Argosy.Common.Contracts.Core.Extensions;
//using Argosy.Common.Contracts.Core.Interfaces;
//using Path = System.IO.Path;

//namespace Cerqa.Common.V5.ArgosyFile
//{
//    public static class FileFactory
//    {
//        public static IFileInfo GetInstance(Uri uri)
//        {
//            if (HttpContext.Current == null)
//            {
//                throw new Exception("URI parsing requires a valid HttpContext");
//            }
//            if (uri == null || string.IsNullOrWhiteSpace(uri.AbsolutePath))
//            {
//                throw new Exception("URI cannot be null");
//            }
//            return GetInstance(new FileInfo(HostingEnvironment.MapPath(HttpUtility.UrlDecode(uri.AbsolutePath))), new List<FileParameter>());
//        }

//        public static IFileInfo GetInstance(List<FileParameter> parameters)
//        {
//            if (parameters.All(a => a.Key != Parameters.FileLocation.ToString()))
//            {
//                throw new Exception(Parameters.FileLocation + " is a required parameter.");
//            }
//            if (parameters.All(a => a.Key != Parameters.FileName.ToString()))
//            {
//                throw new Exception(Parameters.FileName + " is a required parameter.");
//            }
//            var parameterArray = new List<object>();
//            foreach (Parameters value in Enum.GetValues(typeof(Parameters)))
//            {
//                if (parameters.Any(a => a.Key == value.ToString()))
//                {
//                    if (value == Parameters.FileLocation)
//                    {
//                        parameterArray.Add(Enum.Parse(typeof(FileLocations), parameters.First(p => p.Key == value.ToString()).Value.ToString()));
//                    }
//                    else
//                    {
//                        parameterArray.Add(parameters.First(p => p.Key == value.ToString()).Value);
//                    }
//                }
//                else
//                {
//                    parameterArray.Add(null);
//                }
//            }

//            MethodInfo method = null;

//            method = typeof(FileFactory).GetMethod("GetInstance", new Type[] {
//                                                                        typeof (FileLocations),
//                                                                        typeof (string),
//                                                                        typeof (int?),
//                                                                        typeof (int?),
//                                                                        typeof (int?),
//                                                                        typeof (int?),
//                                                                        typeof (int?),
//                                                                        typeof (DateTime?),
//                                                                        typeof (int?),
//                                                                        typeof (string),
//                                                                        typeof (string),
//                                                                        typeof(string),
//                                                                        typeof(string),
//                                                                        typeof (int?)
//                                                                    });

//            return (IFileInfo)method.Invoke(null, parameterArray.ToArray());
//        }

//        public static IFileInfo GetInstance(string path)
//        {
//            if (path.IsUncOrLocalPath())
//            {
//                return GetInstance(new FileInfo(path));
//                //return FileFactory.GetInstance(path);
//            }
//            if (path.IsUriPath())
//            {
//                return GetInstance(new Uri(path));
//            }
//            try
//            {
//                path = HttpContext.Current.Server.MapPath(path);
//                return GetInstance(new FileInfo(path));
//            }
//            catch { }
//            return null;
//        }

//        //public static IFileInfo GetInstance(string path, string fileName, List<FileParameter> parameters = null)
//        //{
//        //    string filenameFromPossibleUnc;
//        //    var finalPath = string.Empty;
//        //    var uncPath = FileUtility.GetFolderPathFromFilePath(fileName, out filenameFromPossibleUnc);
//        //    fileName = FileUtility.ReplaceIllegalCharactersFromFileName(filenameFromPossibleUnc);
//        //    if (!string.IsNullOrEmpty(fileName))
//        //    {
//        //        finalPath = Path.Combine(uncPath, fileName);
//        //    }
//        //    return GetInstance(new FileInfo(path + finalPath), parameters, fileName);
//        //}

//        //public static IFileInfo GetInstance(FileInfo file, List<FileParameter> parameters = null, string fileName = null)
//        //{
//        //    if (parameters == null)
//        //    {
//        //        parameters = new List<FileParameter>();
//        //    }
//        //    if (fileName == null)
//        //    {
//        //        fileName = file.Name;
//        //    }
//        //    parameters.Add(new FileParameter(Parameters.FileName.ToString(), fileName));
//        //    var fileStore = ConfigurationManager.AppSettings.Get("ArgosyFileStore");
//        //    var fileLocation = GetFileLocationFromPath(file.FullName);
//        //    parameters.Add(new FileParameter(Parameters.SubDirectory.ToString(), ParseSubDirectory(file, fileLocation)));
//        //    switch (fileStore.ToLower())
//        //    {
//        //        /*case "azure":
//        //            return new AzureFile(file, fileLocation, parameters);*/
//        //        default:
//        //            return new SystemFile(file, fileLocation, parameters);
//        //    }
//        //}

//        //private static string ParseSubDirectory(FileInfo file, FileLocations location)
//        //{
//        //    var subDir = "";
//        //    if (file.Directory == null)
//        //    {
//        //        return subDir;
//        //    }
//        //    switch (location)
//        //    {
//        //        case FileLocations.DamAsset:
//        //            subDir = file.Directory.FullName.Replace(DamAssetUnc, "");
//        //            break;
//        //        case FileLocations.DamCache:
//        //            subDir = file.Directory.FullName.Replace(DamCacheUnc, "");
//        //            break;
//        //    }
//        //    if (!string.IsNullOrWhiteSpace(subDir) && !subDir.EndsWith("\\"))
//        //    {
//        //        subDir += "\\";
//        //    }
//        //    return subDir;
//        //}

//        public enum Parameters
//        {
//            FileLocation,
//            FileName,
//            SiteId,
//            CompanyId,
//            UserId,
//            RetailProjectId,
//            RetailVersionId,
//            Date,
//            CommuncationId,
//            ProjectPath,
//            DirectoryGuid,
//            TransactionId,
//            SubDirectory,
//            CustomizationStateId
//        }

//        public static IFileInfo GetInstance(FileLocations fileLocation, 
//            string fileName, 
//            int? siteId = null, 
//            int? companyId = null, 
//            int? userId = null, 
//            int? retailProjectId = null, 
//            int? retailVersionId = null,
//            DateTime? date = null, 
//            int? communicationId = null, 
//            string projectPath = null, 
//            string directoryGuid = null, 
//            string transactionId = null, 
//            string subDirectory = null, 
//            int? customizationStateId = null)
//        {
//            List<FileParameter> parameters;
//            var basePath = GetBasePath(fileLocation, out parameters, siteId, companyId, userId, retailProjectId, retailVersionId, date, projectPath, directoryGuid, communicationId, transactionId, customizationStateId);
//            return GetInstance(basePath, (subDirectory ?? "") + fileName, parameters);
//        }

//        public static IFileInfo GetInstance(FileLocations fileLocation, string fileName, int? siteId, DateTime? date)
//        {
//            List<FileParameter> parameters;
//            return GetInstance(GetBasePath(fileLocation, out parameters, siteId, null, null, null, null, date), fileName, parameters);
//        }

//        public static IFileInfo GetInstance(FileLocations fileLocation, string fileName, int? siteId, string projectDirectory)
//        {
//            List<FileParameter> parameters;
//            return GetInstance(GetBasePath(fileLocation, out parameters, siteId, null, null, null, null, null, projectDirectory), fileName, parameters);
//        }

//        public static IFileInfo GetInstance(FileLocations fileLocation, string fileName, Guid directoryGuid)
//        {
//            List<FileParameter> parameters;
//            return GetInstance(GetBasePath(fileLocation, out parameters, null, null, null, null, null, null, null, directoryGuid.ToString()), fileName, parameters);
//        }

//        public static string GetFileName(string originalFileName, int? siteId = null, int? companyId = null)
//        {
//            var fileName = "";
//            if (siteId.HasValue)
//            {
//                fileName += siteId.Value + "_";
//            }
//            if (companyId.HasValue)
//            {
//                fileName += companyId.Value + "_";
//            }
//            fileName += DateTime.Now.Ticks + FileUtility.GetFileNameFileExtension(originalFileName);
//            return fileName;
//        }

//        public static int FileStorageId
//        {
//            get
//            {
//                return Convert.ToInt32(ConfigurationManager.AppSettings["StorageId"]);
//            }
//        }

//        //private static string GetBasePath(FileLocations location, out List<FileParameter> parameters, int? siteId = null, int? companyId = null, int? userId = null, int? retailProjectId = null, int? retailVersionId = null, DateTime? date = null, string projectPath = null, string directoryGuid = null, int? communicationId = null, string transactionId = null, int? customizationStateId = null)
//        //{
//        //    var pathRequirements = location.GetPathRequirements();
//        //    parameters = GetParameters(location, siteId, companyId, userId, retailProjectId, retailVersionId, date, projectPath, directoryGuid, communicationId, customizationStateId);
//        //    if (pathRequirements.RequireCustomizationStateId && !customizationStateId.HasValue)
//        //    {
//        //        throw new InvalidDataException("Customization state id is required to save to " + location);
//        //    }
//        //    if (pathRequirements.RequireSite && !siteId.HasValue)
//        //    {
//        //        throw new InvalidDataException("Site is required to save to " + location);
//        //    }
//        //    if (!pathRequirements.RequireSite && siteId.HasValue)
//        //    {
//        //        throw new InvalidDataException("Site is not required to save to " + location);
//        //    }
//        //    if (pathRequirements.RequireCompany && !companyId.HasValue)
//        //    {
//        //        throw new InvalidDataException("Company is required to save to " + location);
//        //    }
//        //    if (!pathRequirements.RequireCompany && companyId.HasValue)
//        //    {
//        //        throw new InvalidDataException("Company is not required to save to " + location);
//        //    }
//        //    if (pathRequirements.RequireUser && !userId.HasValue)
//        //    {
//        //        throw new InvalidDataException("User is required to save to " + location);
//        //    }
//        //    if (!pathRequirements.RequireUser && userId.HasValue)
//        //    {
//        //        throw new InvalidDataException("User is not required to save to " + location);
//        //    }
//        //    if (pathRequirements.RequireRetailProjectId && !retailProjectId.HasValue)
//        //    {
//        //        throw new InvalidDataException("Retail Project is required to save to " + location);
//        //    }
//        //    if (!pathRequirements.RequireRetailProjectId && retailProjectId.HasValue)
//        //    {
//        //        throw new InvalidDataException("Retail Project is not required to save to " + location);
//        //    }
//        //    if (pathRequirements.RequireRetailVersionId && !retailVersionId.HasValue)
//        //    {
//        //        throw new InvalidDataException("Retail Version is required to save to " + location);
//        //    }
//        //    if (!pathRequirements.RequireRetailVersionId && retailVersionId.HasValue)
//        //    {
//        //        throw new InvalidDataException("Retail Version is not required to save to " + location);
//        //    }
//        //    if (pathRequirements.RequireDate && !date.HasValue)
//        //    {
//        //        throw new InvalidDataException("Date is required to save to " + location);
//        //    }
//        //    if (!pathRequirements.RequireDate && date.HasValue)
//        //    {
//        //        throw new InvalidDataException("Date is not required to save to " + location);
//        //    }
//        //    if (pathRequirements.RequireProjectPath && string.IsNullOrWhiteSpace(projectPath))
//        //    {
//        //        throw new InvalidDataException("Project Path is required to save to " + location);
//        //    }
//        //    if (!pathRequirements.RequireProjectPath && !string.IsNullOrWhiteSpace(projectPath))
//        //    {
//        //        throw new InvalidDataException("Project Path is not required to save to " + location);
//        //    }
//        //    if (pathRequirements.RequireGuid && string.IsNullOrWhiteSpace(directoryGuid))
//        //    {
//        //        throw new InvalidDataException("Directory GUID is required to save to " + location);
//        //    }
//        //    if (!pathRequirements.RequireGuid && !string.IsNullOrWhiteSpace(directoryGuid))
//        //    {
//        //        throw new InvalidDataException("Directory GUID is not required to save to " + location);
//        //    }
//        //    if (pathRequirements.RequireCommunicationId && !communicationId.HasValue)
//        //    {
//        //        throw new InvalidDataException("Directory Communication Identifier is required to save to " + location);
//        //    }
//        //    if (!pathRequirements.RequireCommunicationId && communicationId.HasValue)
//        //    {
//        //        throw new InvalidDataException("Directory Communication Identifier is not required to save to " + location);
//        //    }
//        //    if (pathRequirements.RequireTransactionId && string.IsNullOrWhiteSpace(transactionId))
//        //    {
//        //        throw new InvalidDataException("Transaction Id is required to save to " + location);
//        //    }
//        //    if (!pathRequirements.RequireTransactionId && !string.IsNullOrWhiteSpace(transactionId))
//        //    {
//        //        throw new InvalidDataException("Transaction Id is not required to save to " + location);
//        //    }

//            //var path = "";
//            //switch (location)
//            //{
//            //    case FileLocations.SystemStatic:
//            //        path = SystemStaticUnc;
//            //        break;
//            //    case FileLocations.SystemDynamic:
//            //        path = SystemDynamicUnc;
//            //        break;
//            //    case FileLocations.SiteLogo:
//            //        path = string.Format(SiteLogoUnc, siteId.Value);
//            //        break;
//            //    case FileLocations.CustomerLogo:
//            //        path = string.Format(CustomerLogoUnc, companyId.Value);
//            //        break;
//            //    case FileLocations.CustomerCustomLink:
//            //        path = string.Format(CustomerCustomLinkUnc, companyId.Value);
//            //        break;
//            //    case FileLocations.CompanyWebStore:
//            //        path = string.Format(CompanyWebStoreUnc, siteId.Value, companyId.Value);
//            //        break;
//            //    case FileLocations.PartLogo:
//            //        path = string.Format(PartLogoUnc, siteId.Value);
//            //        break;
//            //    case FileLocations.PromoImage:
//            //        path = string.Format(PromoImageUnc, siteId.Value);
//            //        break;
//            //    case FileLocations.ProjectRevision:
//            //        path = string.Format(ProjectRevisionUnc, siteId.Value);
//            //        break;
//            //    case FileLocations.Reports:
//            //        path = ReportsUnc;
//            //        break;
//            //    case FileLocations.DamAsset:
//            //        path = DamAssetUnc;
//            //        break;
//            //    case FileLocations.Chunk:
//            //        path = string.Format(ChunkUnc, directoryGuid);
//            //        break;
//            //    case FileLocations.DamCache:
//            //        path = DamCacheUnc;
//            //        break;
//            //    case FileLocations.DamDefaultImage:
//            //        path = DamDefaultImageUnc;
//            //        break;
//            //    case FileLocations.DamTemp:
//            //        path = DamTempUnc;
//            //        break;
//            //    case FileLocations.Asset:
//            //        path = string.Format(AssetsUnc, siteId.Value, GetDateString(date));
//            //        break;
//            //    case FileLocations.AssetUser:
//            //        path = string.Format(AssetsUnc, siteId.Value, userId.Value);
//            //        break;
//            //    case FileLocations.AssetCompany:
//            //        path = string.Format(AssetsCompanyUnc, companyId.Value);
//            //        break;
//            //    case FileLocations.GlobalFormUpload:
//            //        path = string.Format(GlobalFormUploadUnc, siteId.Value);
//            //        break;
//            //    case FileLocations.ImportProcessing:
//            //        path = ImportProcessingUnc;
//            //        break;
//            //    case FileLocations.TempStorage:
//            //        path = TempStorageUnc;
//            //        break;
//            //    case FileLocations.CommunicationAttachment:
//            //        path = string.Format(CommunicationAttachmentUnc, communicationId.Value);
//            //        break;
//            //    case FileLocations.TempStorageCompany:
//            //        path = string.Format(TempStorageCompanyUnc, siteId.Value, companyId.Value);
//            //        break;
//            //    case FileLocations.TempStorageSite:
//            //        path = string.Format(TempStorageSiteUnc, siteId.Value);
//            //        break;
//            //    case FileLocations.TempStorageUser:
//            //        path = string.Format(TempStorageUserUnc, siteId.Value, userId.Value);
//            //        break;
//            //    case FileLocations.Order:
//            //        path = string.Format(OrdersUnc, siteId.Value, GetDateString(date));
//            //        break;
//            //    case FileLocations.Retail:
//            //        path = string.Format(RetailUnc, siteId.Value, retailProjectId.Value, retailVersionId.Value);
//            //        break;
//            //    case FileLocations.ShortTermTemp:
//            //        path = ShortTermTempUnc;
//            //        break;
//            //    case FileLocations.Upload:
//            //        path = string.Format(UploadsUnc, companyId.Value);
//            //        break;
//            //    case FileLocations.VendorOrder:
//            //        path = string.Format(VendorOrderUnc, siteId.Value);
//            //        break;
//            //    case FileLocations.VendorShipment:
//            //        path = string.Format(VendorShipmentUnc, siteId.Value);
//            //        break;
//            //    case FileLocations.PartConfiguration:
//            //        path = string.Format(PartConfigurationUnc, siteId.Value);
//            //        break;
//            //    case FileLocations.ImageBankProd:
//            //        path = ImageBankProd;
//            //        break;
//            //    case FileLocations.CustomSoftProofingProject:
//            //        path = Path.Combine(CustomSoftProofingUNC, projectPath);
//            //        break;
//            //    case FileLocations.CustomSoftProofingProjectImages:
//            //        path = Path.Combine(CustomSoftProofingImagesUNC, projectPath);
//            //        break;
//            //    case FileLocations.SoftProofingProject:
//            //        path = string.Format(SoftProofingUNC, siteId.Value, projectPath);
//            //        break;
//            //    case FileLocations.SoftProofingDesignTemplate:
//            //        path = string.Format(SoftProofingDesignTemplateUNC, siteId.Value);
//            //        break;
//            //    case FileLocations.SoftProofingProjectImages:
//            //        path = string.Format(SoftProofingImagesUNC, siteId.Value, projectPath);
//            //        break;
//            //    case FileLocations.SoftProofingVariableImages:
//            //        path = string.Format(SoftProofingVariableImagesUnc, siteId.Value);
//            //        break;
//            //    case FileLocations.WebTemp:
//            //        path = WebTempUnc;
//            //        break;
//            //    case FileLocations.AppUpdateUploads:
//            //        path = AppUpdateUploadsUnc;
//            //        break;
//            //    case FileLocations.IntegrationsInbound:
//            //        path = string.Format(IntegrationsInboundUnc, siteId.Value, companyId.Value);
//            //        break;
//            //    case FileLocations.IntegrationsInboundProcessed:
//            //        path = string.Format(IntegrationsInboundProcessedUnc, siteId.Value, companyId.Value);
//            //        break;
//            //    case FileLocations.IntegrationsInboundProcessing:
//            //        path = string.Format(IntegrationsInboundProcessingUnc, siteId.Value, companyId.Value);
//            //        break;
//            //    case FileLocations.IntegrationsOutbound:
//            //        path = string.Format(IntegrationsOutboundUnc, siteId.Value, companyId.Value);
//            //        break;
//            //    case FileLocations.IntegrationsInboundErrors:
//            //        path = string.Format(IntegrationsInboundErrorsUnc, siteId.Value, companyId.Value);
//            //        break;
//            //    case FileLocations.IntegrationsTemp:
//            //        path = string.Format(IntegrationsTempUnc);
//            //        break;
//            //    case FileLocations.CompanyHtmlContent:
//            //        path = string.Format(CompanyHtmlContentUnc, companyId.Value);
//            //        break;
//            //    case FileLocations.PageFlexTempStorage:
//            //        path = string.Format(PageFlexTempStorageUnc, transactionId);
//            //        break;
//            //    case FileLocations.PageFlexTempStorageThumbnail:
//            //        path = string.Format(PageFlexTempStorageThumbnailUnc, transactionId);
//            //        break;
//            //    case FileLocations.CustomizationState:
//            //        path = string.Format(CustomizationStateUnc, siteId.Value, companyId.Value, userId.Value, customizationStateId.Value);
//            //        break;
//            //    case FileLocations.UserGroup:
//            //        path = string.Format(UserGroupUnc, siteId.Value, companyId.Value);
//            //        break;
//            //    case FileLocations.Cloud:
//            //        path = string.Format(CloudUnc);
//            //        break;
//            //}
//            //return path;
//       // }

//        public static IFileInfo GetInstance(FileLocations userGroup, string name, object siteId)
//        {
//            throw new NotImplementedException();
//        }
        

//        private static List<FileParameter> GetParameters(FileLocations fileLocation, int? siteId, int? companyId, int? userId, int? retailProjectId, int? retailVersionId, DateTime? date, string projectPath, string directoryGuid, int? communicationId, int? customizationStateId)
//        {
//            var parameters = new List<FileParameter>
//            {
//                new FileParameter(Parameters.FileLocation.ToString(), fileLocation.ToString())
//            };
//            if (siteId.HasValue)
//            {
//                parameters.Add(new FileParameter(Parameters.SiteId.ToString(), siteId.Value));
//            }
//            if (companyId.HasValue)
//            {
//                parameters.Add(new FileParameter(Parameters.CompanyId.ToString(), companyId.Value));
//            }
//            if (userId.HasValue)
//            {
//                parameters.Add(new FileParameter(Parameters.UserId.ToString(), userId.Value));
//            }
//            if (retailVersionId.HasValue)
//            {
//                parameters.Add(new FileParameter(Parameters.RetailVersionId.ToString(), retailVersionId.Value));
//            }
//            if (retailProjectId.HasValue)
//            {
//                parameters.Add(new FileParameter(Parameters.RetailProjectId.ToString(), retailProjectId.Value));
//            }
//            if (date.HasValue)
//            {
//                parameters.Add(new FileParameter(Parameters.Date.ToString(), date.Value));
//            }
//            if (!string.IsNullOrWhiteSpace(projectPath))
//            {
//                parameters.Add(new FileParameter(Parameters.ProjectPath.ToString(), projectPath));
//            }
//            if (!string.IsNullOrWhiteSpace(directoryGuid))
//            {
//                parameters.Add(new FileParameter(Parameters.DirectoryGuid.ToString(), directoryGuid));
//            }
//            if (communicationId.HasValue)
//            {
//                parameters.Add(new FileParameter(Parameters.CommuncationId.ToString(), communicationId.Value));
//            }
//            if (customizationStateId.HasValue)
//            {
//                parameters.Add(new FileParameter(Parameters.CustomizationStateId.ToString(), customizationStateId.Value));
//            }
//            return parameters;
//        }

//        internal static FileLocations GetFileLocationFromPath(string path)
//        {
//            var location = FileLocations.WebTemp;
//            var type = typeof(FileFactory);
//            foreach (var property in type.GetProperties())
//            {
//                var val = GetValue(property);
//                if (!string.IsNullOrWhiteSpace(val) && path.ToLower().Contains(val.ToLower()))
//                {
//                    location = property.GetPathLocation();
//                }
//            }
//            return location;
//        }

//        private static string GetValue(PropertyInfo property)
//        {
//            var obj = property.GetValue(null, null);
//            string val = obj is string ? (string)obj : null;
//            if (!string.IsNullOrWhiteSpace(val))
//            {
//                val = val.Replace(@"\{0}", "");
//                val = val.Replace(@"\{1}", "");
//                val = val.Replace(@"\{2}", "");
//                val = val.Replace(@"\{3}", "");
//                val = val.Replace(@"\{4}", "");
//                val = val.Replace(@"\{5}", "");
//            }
//            return val;
//        }

//        private static string GetDateString(DateTime? date)
//        {
//            return date.Value.ToShortDateString().Replace("/", "-");
//        }
//        private static string DriveLetter { get; set; }
//        public static string GetOverridePath(string root)
//        {
//            if (IsDevOverrideMachine)
//            {
//                return @"\\ausdev02\Share\" + root;
//            }
//            if (IsLocalOverrideMachine)
//            {
//                return @"D:\development\Propago\Source\Share\" + root;
//            }
//            return null;
//        }

//        public static bool IsDevOverrideMachine
//        {
//            get
//            {
//                var machineName = Environment.MachineName;
//                switch (machineName.ToUpper(CultureInfo.CurrentCulture))
//                {
//                    case "AUSDEV02": //hangfire
//                    case "GJFDDX1":
//                    case "C6WSDZ1": //andrew
//                    case "H5RPPD2": //chris
//                    case "C6WTDZ1":
//                    case "H5VPPD2": //brian
//                    case "9QD9XG2": //parker
//                    case "DESKTOP-6PGM5N9": // luka
//                        DriveLetter = "D";
//                        return true;
//                }
//                return false;
//            }
//        }

//        public static bool IsLocalOverrideMachine
//        {
//            get
//            {
//                string machineName = Environment.MachineName;
//                switch (machineName.ToUpper(CultureInfo.CurrentCulture))
//                {
//                    case "ANDREW-OCULUS":
//                    case "ANDREW-DESKTOP": // andrew home
//                    case "OFFICE-PC": // brian home
//                        return true;
//                }
//                return false;
//            }
//        }

//        //[RootLocation(FileLocations.SystemStatic)]
//        //public static string SystemStaticUnc
//        //{
//        //    get { return GetOverridePath(@"SystemStatic\") ?? AppSetting.SystemStaticUnc; }
//        //}

//        //[RootLocation(FileLocations.Integrations)]
//        //public static string IntegrationsUnc
//        //{
//        //    get { return GetOverridePath(@"Integrations\") ?? AppSetting.IntegrationsUnc; }
//        //}

//        //[RootLocation(FileLocations.DamRoot)]
//        //public static string DamRootUnc
//        //{
//        //    get
//        //    {
//        //        var damRoot = AppSetting.DamRootUnc;
//        //        if (string.IsNullOrWhiteSpace(damRoot))
//        //        {
//        //            damRoot = SystemStaticUnc + @"Dam\";
//        //        }
//        //        return GetOverridePath(@"SystemStatic\Dam\") ?? damRoot;
//        //    }
//        //}

//        //[RootLocation(FileLocations.SystemDynamic)]
//        //internal static string SystemDynamicUnc
//        //{
//        //    get { return GetOverridePath(@"SystemDynamic\") ?? AppSetting.SystemDynamicUnc; }
//        //}

//        //[RootLocation(FileLocations.ImageBankProd)]
//        //internal static string ImageBankProd
//        //{
//        //    get
//        //    {
//        //        return AppSetting.ImageBankProdUnc;
//        //    }
//        //}

//        //[PathFileLocation(FileLocations.SiteLogo)]
//        //public static string SiteLogoUnc
//        //{
//        //    get
//        //    {
//        //        return SystemStaticUnc + @"SiteImages\{0}\";
//        //    }
//        //}

//        //[PathFileLocation(FileLocations.CustomSoftProofingProject)]
//        //public static string CustomSoftProofingUNC
//        //{
//        //    get
//        //    {
//        //        return SystemStaticUnc + @"CustomSoftProofing\Projects\{0}\";
//        //    }
//        //}

//        //[PathFileLocation(FileLocations.CustomSoftProofingProjectImages)]
//        //public static string CustomSoftProofingImagesUNC
//        //{
//        //    get
//        //    {
//        //        return SystemStaticUnc + @"CustomSoftProofing\Projects\{0}\Images\";
//        //    }
//        //}

//        //[PathFileLocation(FileLocations.WebTemp)]
//        //public static string WebTempUnc
//        //{
//        //    get
//        //    {
//        //        return @"..\tmp\";
//        //    }
//        //}

//        //[PathFileLocation(FileLocations.SoftProofingProject)]
//        //public static string SoftProofingUNC
//        //{
//        //    get
//        //    {
//        //        return SoftProofingRootUNC + @"Projects\{0}\{1}\";
//        //    }
//        //}

//        //public static string SoftProofingRootUNC
//        //{
//        //    get
//        //    {
//        //        return SystemStaticUnc + @"SoftProofing\";
//        //    }
//        //}

//        //[PathFileLocation(FileLocations.SoftProofingDesignTemplate)]
//        //public static string SoftProofingDesignTemplateUNC
//        //{
//        //    get
//        //    {
//        //        return SoftProofingRootUNC + @"DesignTemplate\{0}\";
//        //    }
//        //}

//        //[PathFileLocation(FileLocations.SoftProofingProjectImages)]
//        //public static string SoftProofingImagesUNC
//        //{
//        //    get
//        //    {
//        //        return SoftProofingRootUNC + @"Projects\{0}\{1}\Images\";
//        //    }
//        //}


//        //[PathFileLocation(FileLocations.CompanyWebStore)]
//        //public static string CompanyWebStoreUnc
//        //{
//        //    get
//        //    {
//        //        return SystemStaticUnc + @"CompanyPages\{0}\{1}\";
//        //    }
//        //}

//        //[PathFileLocation(FileLocations.CustomerCustomLink)]
//        //public static string CustomerCustomLinkUnc
//        //{
//        //    get
//        //    {
//        //        return SystemStaticUnc + @"CustomerImages\CustomLinks\{0}\";
//        //    }
//        //}

//        //[PathFileLocation(FileLocations.CustomerLogo)]
//        //public static string CustomerLogoUnc
//        //{
//        //    get
//        //    {
//        //        return SystemStaticUnc + @"CustomerImages\{0}\";
//        //    }
//        //}

//        //[PathFileLocation(FileLocations.CustomerLogo)]
//        //public static string CompanyHtmlContentUnc
//        //{
//        //    get
//        //    {
//        //        return CustomerLogoUnc + @"HtmlContent\";
//        //    }
//        //}

//        //[PathFileLocation(FileLocations.PartLogo)]
//        //public static string PartLogoUnc
//        //{
//        //    get
//        //    {
//        //        return SystemStaticUnc + @"PartImages\{0}\";
//        //    }
//        //}

//        //[PathFileLocation(FileLocations.PromoImage)]
//        //public static string PromoImageUnc
//        //{
//        //    get
//        //    {
//        //        return SystemStaticUnc + @"PromoImages\{0}\";
//        //    }
//        //}

//        //[PathFileLocation(FileLocations.ProjectRevision)]
//        //public static string ProjectRevisionUnc
//        //{
//        //    get
//        //    {
//        //        return SystemStaticUnc + @"ProjectRevisions\{0}\";
//        //    }
//        //}

//        //[PathFileLocation(FileLocations.Reports)]
//        //public static string ReportsUnc
//        //{
//        //    get
//        //    {
//        //        return SystemStaticUnc + @"Reports\";
//        //    }
//        //}

//        //[PathFileLocation(FileLocations.DamAsset)]
//        //public static string DamAssetUnc
//        //{
//        //    get
//        //    {
//        //        return DamRootUnc + @"Assets\";
//        //    }
//        //}

//        //[PathFileLocation(FileLocations.DamCache)]
//        //public static string DamCacheUnc
//        //{
//        //    get
//        //    {
//        //        return DamRootUnc + @"Cache\";
//        //    }
//        //}

//        //[PathFileLocation(FileLocations.DamDefaultImage)]
//        //public static string DamDefaultImageUnc
//        //{
//        //    get
//        //    {
//        //        return DamRootUnc + @"DefaultImages\";
//        //    }
//        //}

//        //[PathFileLocation(FileLocations.DamTemp)]
//        //public static string DamTempUnc
//        //{
//        //    get
//        //    {
//        //        return DamRootUnc + @"Temp\";
//        //    }
//        //}

//        //[PathFileLocation(FileLocations.Asset)]
//        //public static string AssetsUnc
//        //{
//        //    get
//        //    {
//        //        return SystemDynamicUnc + @"Assets\{0}\{1}\";
//        //    }
//        //}
//        //[PathFileLocation(FileLocations.CustomizationState)]
//        //public static string CustomizationStateUnc
//        //{
//        //    get
//        //    {
//        //        return SystemDynamicUnc + @"CustomizationState\{0}\{1}\{2}\{3}\";
//        //    }
//        //}
//        //[PathFileLocation(FileLocations.UserGroup)]
//        //public static string UserGroupUnc
//        //{
//        //    get
//        //    {
//        //        return SystemStaticUnc + @"UserGroup\{0}\{1}\";
//        //    }
//        //}
//        //[PathFileLocation(FileLocations.CustomizationStateThumbnail)]
//        //public static string CustomizationStateThumbnailUnc
//        //{
//        //    get
//        //    {
//        //        return CustomizationStateUnc + @"Images\";
//        //    }
//        //}
//        //[PathFileLocation(FileLocations.PageFlexTempStorage)]
//        //public static string PageFlexTempStorageUnc
//        //{
//        //    get
//        //    {
//        //        return TempStorageUnc + @"{0}\";
//        //    }
//        //}

//        //[PathFileLocation(FileLocations.PageFlexTempStorageThumbnail)]
//        //public static string PageFlexTempStorageThumbnailUnc
//        //{
//        //    get
//        //    {
//        //        return PageFlexTempStorageUnc + @"Images\";
//        //    }
//        //}

//        //[PathFileLocation(FileLocations.Asset)]
//        //public static string AssetsCompanyUnc
//        //{
//        //    get
//        //    {
//        //        return SystemDynamicUnc + @"Assets\{0}\";
//        //    }
//        //}

//        //[PathFileLocation(FileLocations.CommunicationAttachment)]
//        //public static string CommunicationAttachmentUnc
//        //{
//        //    get
//        //    {
//        //        return SystemDynamicUnc + @"CommunicationAttachments\{0}\";
//        //    }
//        //}

//        //[PathFileLocation(FileLocations.GlobalFormUpload)]
//        //public static string GlobalFormUploadUnc
//        //{
//        //    get
//        //    {
//        //        return SystemDynamicUnc + @"GlobalFormUpload\{0}\";
//        //    }
//        //}

//        //[PathFileLocation(FileLocations.ImportProcessing)]
//        //public static string ImportProcessingUnc
//        //{
//        //    get
//        //    {
//        //        return SystemDynamicUnc + @"ImportProcessing\";
//        //    }
//        //}

//        //[PathFileLocation(FileLocations.TempStorage)]
//        //public static string TempStorageUnc
//        //{
//        //    get
//        //    {
//        //        return SystemDynamicUnc + @"NewTempStorage\";
//        //    }
//        //}

//        //[PathFileLocation(FileLocations.TempStorageSite)]
//        //public static string TempStorageSiteUnc
//        //{
//        //    get
//        //    {
//        //        return TempStorageUnc + @"Site\{0}\";
//        //    }
//        //}

//        //[PathFileLocation(FileLocations.TempStorageCompany)]
//        //public static string TempStorageCompanyUnc
//        //{
//        //    get
//        //    {
//        //        return TempStorageUnc + @"Company\{0}\{1}\";
//        //    }
//        //}

//        //[PathFileLocation(FileLocations.TempStorageUser)]
//        //public static string TempStorageUserUnc
//        //{
//        //    get
//        //    {
//        //        return TempStorageUnc + @"User\{0}\{1}\";
//        //    }
//        //}

//        //[PathFileLocation(FileLocations.Order)]
//        //public static string OrdersUnc
//        //{
//        //    get
//        //    {
//        //        return SystemDynamicUnc + @"Orders\{0}\{1}\";
//        //    }
//        //}

//        //[PathFileLocation(FileLocations.Retail)]
//        //public static string RetailUnc
//        //{
//        //    get
//        //    {
//        //        return SystemDynamicUnc + @"Retail\{0}\{1}\{2}\";
//        //    }
//        //}

//        //[PathFileLocation(FileLocations.ShortTermTemp)]
//        //public static string ShortTermTempUnc
//        //{
//        //    get
//        //    {
//        //        return SystemDynamicUnc + @"ShortTermTemp\";
//        //    }
//        //}

//        //[PathFileLocation(FileLocations.Chunk)]
//        //public static string ChunkUnc
//        //{
//        //    get
//        //    {
//        //        return SystemDynamicUnc + @"UploadChunk\{0}\";
//        //    }
//        //}
//        //[PathFileLocation(FileLocations.Upload)]
//        //public static string UploadsUnc
//        //{
//        //    get
//        //    {
//        //        return SystemDynamicUnc + @"Uploads\{0}\";
//        //    }
//        //}

//        //[PathFileLocation(FileLocations.VendorOrder)]
//        //public static string VendorOrderUnc
//        //{
//        //    get
//        //    {
//        //        return SystemDynamicUnc + @"Vendor\Orders\{0}\";
//        //    }
//        //}

//        //[PathFileLocation(FileLocations.VendorShipment)]
//        //public static string VendorShipmentUnc
//        //{
//        //    get
//        //    {
//        //        return SystemDynamicUnc + @"Vendor\Shipments\{0}\";
//        //    }
//        //}

//        //[PathFileLocation(FileLocations.PartConfiguration)]
//        //public static string PartConfigurationUnc
//        //{
//        //    get
//        //    {
//        //        return SystemStaticUnc + @"PartConfigurationImages\{0}\";
//        //    }
//        //}

//        //[PathFileLocation(FileLocations.SoftProofingVariableImages)]
//        //public static string SoftProofingVariableImagesUnc
//        //{
//        //    get
//        //    {
//        //        return SystemStaticUnc + @"SoftProofing\SoftProofingVariableImages\{0}\";
//        //    }
//        //}

//        //[PathFileLocation(FileLocations.AppUpdateUploads)]
//        //public static string AppUpdateUploadsUnc
//        //{
//        //    get
//        //    {
//        //        return SystemStaticUnc + @"AppUpdateUploads\";
//        //    }
//        //}

//        //[PathFileLocation(FileLocations.IntegrationsInbound)]
//        //public static string IntegrationsInboundUnc
//        //{
//        //    get
//        //    {
//        //        return IntegrationsUnc + @"{0}\{1}\Inbound\";
//        //    }
//        //}
//        //[PathFileLocation(FileLocations.IntegrationsInboundProcessed)]
//        //public static string IntegrationsInboundProcessedUnc
//        //{
//        //    get
//        //    {
//        //        return IntegrationsUnc + @"{0}\{1}\InboundProcessed\";
//        //    }
//        //}
//        //[PathFileLocation(FileLocations.IntegrationsInboundProcessing)]
//        //public static string IntegrationsInboundProcessingUnc
//        //{
//        //    get
//        //    {
//        //        return IntegrationsUnc + @"{0}\{1}\InboundProcessing\";
//        //    }
//        //}
//        //[PathFileLocation(FileLocations.IntegrationsOutbound)]
//        //public static string IntegrationsOutboundUnc
//        //{
//        //    get
//        //    {
//        //        return IntegrationsUnc + @"{0}\{1}\Outbound\";
//        //    }
//        //}
//        //[PathFileLocation(FileLocations.IntegrationsInboundErrors)]
//        //public static string IntegrationsInboundErrorsUnc
//        //{
//        //    get
//        //    {
//        //        return IntegrationsUnc + @"{0}\{1}\InboundErrors\";
//        //    }
//        //}
//        //[PathFileLocation(FileLocations.IntegrationsTemp)]
//        //public static string IntegrationsTempUnc
//        //{
//        //    get
//        //    {
//        //        return IntegrationsUnc + @"Temp\";
//        //    }
//        //}

//        //[PathFileLocation(FileLocations.Cloud)]
//        //public static string CloudUnc
//        //{
//        //    get
//        //    {
//        //        return SystemDynamicUnc + @"Cloud\";
//        //    }
//        //}

//        public static IFileInfo GetUserProfileFileName(int companyId, int userId, string extension = ".png", string name = "_user_photo")
//        {
//            return GetInstance(FileLocations.CustomerLogo, $"{companyId}_{userId}{name}{extension}", null, companyId);
//        }

//        private static bool IsUncOrLocalPath(this string value)
//        {
//            try
//            {
//                if (!string.IsNullOrWhiteSpace(value))
//                {
//                    var path = new Uri(value);
//                    return path.IsUnc || path.IsFile;
//                }
//            }
//            catch
//            {
//            }
//            return false;
//        }

//        private static bool IsUriPath(this string value)
//        {
//            try
//            {
//                if (!string.IsNullOrWhiteSpace(value))
//                {
//                    return value.ToLower().StartsWith("http");
//                }
//            }
//            catch
//            {
//            }
//            return false;
//        }

//        public static IFileInfo GetUniqueFileLocation(IFileInfo tempFile, FileLocations fileLocation, out string pathWithoutRoot)
//        {
//            string name = Guid.NewGuid() + tempFile.Extension;
//            pathWithoutRoot = name;
//            IFileInfo file = FileFactory.GetInstance(fileLocation, pathWithoutRoot);
//            while (file.Exists)
//            {
//                name = Guid.NewGuid() + tempFile.Extension;
//                pathWithoutRoot = name;
//                file = FileFactory.GetInstance(fileLocation, pathWithoutRoot);
//            }
//            return file;
//        }
//    }
//}
