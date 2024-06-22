const LEXICOM_CONCENTRATE_AMENITIES_TAILWINDS_BREAKPOINT_SIZE_DEFAULT = 0;
const LEXICOM_CONCENTRATE_AMENITIES_TAILWINDS_BREAKPOINT_SIZE_SM = 640;
const LEXICOM_CONCENTRATE_AMENITIES_TAILWINDS_BREAKPOINT_SIZE_MD = 768;
const LEXICOM_CONCENTRATE_AMENITIES_TAILWINDS_BREAKPOINT_SIZE_LG = 1024;
const LEXICOM_CONCENTRATE_AMENITIES_TAILWINDS_BREAKPOINT_SIZE_XL = 1280;
const LEXICOM_CONCENTRATE_AMENITIES_TAILWINDS_BREAKPOINT_SIZE_2XL = 1536;

window.lexicomConcentrateAmenitiesUpdateTailwindsBreakpointCallback = (tailwindsServiceReference) => {
    let tailwindsBreakpointSize;

    if (window.innerWidth >= LEXICOM_CONCENTRATE_AMENITIES_TAILWINDS_BREAKPOINT_SIZE_2XL) {
        tailwindsBreakpointSize = LEXICOM_CONCENTRATE_AMENITIES_TAILWINDS_BREAKPOINT_SIZE_2XL;
    }
    else if (window.innerWidth >= LEXICOM_CONCENTRATE_AMENITIES_TAILWINDS_BREAKPOINT_SIZE_XL) {
        tailwindsBreakpointSize = LEXICOM_CONCENTRATE_AMENITIES_TAILWINDS_BREAKPOINT_SIZE_XL;
    }
    else if (window.innerWidth >= LEXICOM_CONCENTRATE_AMENITIES_TAILWINDS_BREAKPOINT_SIZE_LG) {
        tailwindsBreakpointSize = LEXICOM_CONCENTRATE_AMENITIES_TAILWINDS_BREAKPOINT_SIZE_LG;
    }
    else if (window.innerWidth >= LEXICOM_CONCENTRATE_AMENITIES_TAILWINDS_BREAKPOINT_SIZE_MD) {
        tailwindsBreakpointSize = LEXICOM_CONCENTRATE_AMENITIES_TAILWINDS_BREAKPOINT_SIZE_MD;
    }
    else if (window.innerWidth >= LEXICOM_CONCENTRATE_AMENITIES_TAILWINDS_BREAKPOINT_SIZE_SM) {
        tailwindsBreakpointSize = LEXICOM_CONCENTRATE_AMENITIES_TAILWINDS_BREAKPOINT_SIZE_SM;
    }
    else {
        tailwindsBreakpointSize = LEXICOM_CONCENTRATE_AMENITIES_TAILWINDS_BREAKPOINT_SIZE_DEFAULT;
    }

    if (window.lexicomConcentrateAmenitiesCurrentTailwindsBreakpointSize != tailwindsBreakpointSize) {
        window.lexicomConcentrateAmenitiesCurrentTailwindsBreakpointSize = tailwindsBreakpointSize;

        tailwindsServiceReference.invokeMethodAsync('OnJsInvokeAsync', window.lexicomConcentrateAmenitiesCurrentTailwindsBreakpointSize);
    }
}

window.lexicomConcentrateAmenitiesRegisterTailwindsBreakpointCallback = (tailwindsServiceReference) => {
    window.addEventListener('resize', () => {
        window.lexicomConcentrateAmenitiesUpdateTailwindsBreakpointCallback(tailwindsServiceReference);
    });
}

window.lexicomConcentrateAmenitiesCurrentTailwindsBreakpointSize = -1;