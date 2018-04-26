//using Argosy.Common.Contracts.Core.Attributes;

namespace Argosy.Common.Contracts.Core.Enum
{
    public enum FileLocations {
        //[PathRequirements()]
        SystemStatic,
        //[PathRequirements()]
        Integrations,
        //[PathRequirements()]
        SystemDynamic,
        //[PathRequirements()]
        DamRoot,
        //[PathRequirements()]
        DamTemp,
        //[PathRequirements(true)]
        SiteLogo,
        //[PathRequirements(false, true)]
        CustomerLogo,
        //[PathRequirements(true, true)]
        CompanyWebStore,
        //[PathRequirements(false, true)]
        CustomerCustomLink,
        //[PathRequirements(true)]
        PartLogo,
        //[PathRequirements(true)]
        PromoImage,
        //[PathRequirements(false, false, false, false, false, false, false, true)]
        Chunk,
        //[PathRequirements(true)]
        ProjectRevision,
        //[PathRequirements()]
        Reports,
        //[PathRequirements()]
        DamAsset,
        //[PathRequirements()]
        DamCache,
        //[PathRequirements()]
        DamDefaultImage,
        //[PathRequirements(true, false, false, false, false, true)]
        Asset,
        //[PathRequirements(false, true)]
        AssetCompany,
        //[PathRequirements(true, false, true)]
        AssetUser,
        //[PathRequirements(true)]
        GlobalFormUpload,
        //[PathRequirements()]
        ImportProcessing,
        //[PathRequirements()]
        TempStorage,
        //[PathRequirements(true)]
        TempStorageSite,
        //[PathRequirements(true, true)]
        TempStorageCompany,
        //[PathRequirements(true, false, true)]
        TempStorageUser,
        //[PathRequirements(true, false, false, false, false, true)]
        Order,
        //[PathRequirements(true, false, false, true, true)]
        Retail,
        //[PathRequirements()]
        ShortTermTemp,
        //[PathRequirements(false, true)]
        Upload,
        //[PathRequirements(true)]
        VendorOrder,
        //[PathRequirements(true)]
        VendorShipment,
        //[PathRequirements(true)]
        PartConfiguration,
        //[PathRequirements()]
        ImageBankProd,
        //[PathRequirements(false, false, false, false, false, false, true)]
        CustomSoftProofingProject,
        //[PathRequirements(false, false, false, false, false, false, true)]
        CustomSoftProofingProjectImages,
        //[PathRequirements(true, false, false, false, false, false, true)]
        SoftProofingProject,
        //[PathRequirements(true, false, false, false, false, false, true)]
        SoftProofingProjectImages,
        //[PathRequirements(true)]
        SoftProofingVariableImages,
        //[PathRequirements(true)]
        SoftProofingDesignTemplate,
        //[PathRequirements()]
        WebTemp,
        //[PathRequirements()]
        AppUpdateUploads,
        //[PathRequirements(false, false, false, false, false, false, false, false, true)]
        CommunicationAttachment,
        //[PathRequirements(true, true)]
        IntegrationsInbound,
        //[PathRequirements(true, true)]
        IntegrationsInboundProcessed,
        //[PathRequirements(true, true)]
        IntegrationsInboundProcessing,
        //[PathRequirements(true, true)]
        IntegrationsOutbound,
        //[PathRequirements(true, true)]
        IntegrationsInboundErrors,
        //[PathRequirements()]
        IntegrationsTemp,
        //[PathRequirements(false, true)]
        CompanyHtmlContent,
        //[PathRequirements(false, false, false, false, false, false, false, false, false, true)]
        PageFlexTempStorage,
        //[PathRequirements(false, false, false, false, false, false, false, false, false, true)]
        PageFlexTempStorageThumbnail,
        //[PathRequirements(true, true, true, false, false, false, false, false, false, false, true)]
        CustomizationState,
        //[PathRequirements(true, true, true, false, false, false, false, false, false, false, true)]
        CustomizationStateThumbnail,
        //[PathRequirements(true, true)]
        UserGroup,
        //[PathRequirements()]
        Cloud

    }
}