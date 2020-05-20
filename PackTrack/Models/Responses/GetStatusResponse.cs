#region License
/*
	PackTrack
	Copyright(C) 2020 Caprine Logic
	
	This program is free software: you can redistribute it and/or modify
	it under the terms of the GNU General Public License as published by
	the Free Software Foundation, either version 3 of the License, or
	(at your option) any later version.
	
	This program is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
	GNU General Public License for more details.
	
	You should have received a copy of the GNU General Public License
	along with this program. If not, see <https://www.gnu.org/licenses/>.
*/
#endregion License

namespace PackTrack.Models.Responses
{
	public class GetStatusResponse
	{
		public string statusCode { get; set; }
		public string statusText { get; set; }
		public bool isLoggedInUser { get; set; }
		public string trackedDateTime { get; set; }
		public bool isBcdnMultiView { get; set; }
		public TrackDetail[] trackDetails { get; set; }
	}

	public class TrackDetail
	{
		public object errorCode { get; set; }
		public object errorText { get; set; }
		public string requestedTrackingNumber { get; set; }
		public string trackingNumber { get; set; }
		public bool isMobileDevice { get; set; }
		public string packageStatus { get; set; }
		public string packageStatusType { get; set; }
		public string packageStatusCode { get; set; }
		public string progressBarType { get; set; }
		public string progressBarPercentage { get; set; }
		public string simplifiedText { get; set; }
		public string scheduledDeliveryDayCMSKey { get; set; }
		public string scheduledDeliveryDate { get; set; }
		public object noEstimatedDeliveryDateLabel { get; set; }
		public string scheduledDeliveryTime { get; set; }
		public string scheduledDeliveryTimeEODLabel { get; set; }
		public string packageCommitedTime { get; set; }
		public object endOfDayResCMSKey { get; set; }
		public string deliveredDayCMSKey { get; set; }
		public string deliveredDate { get; set; }
		public string deliveredTime { get; set; }
		public string receivedBy { get; set; }
		public object leaveAt { get; set; }
		public object cdiLeaveAt { get; set; }
		public string leftAt { get; set; }
		public ShipToAddress shipToAddress { get; set; }
		public object shipFromAddress { get; set; }
		public object consigneeAddress { get; set; }
		public object signatureTrackingUrl { get; set; }
		public object trackHistoryDescription { get; set; }
		public AdditionalInformation additionalInformation { get; set; }
		public SpecialInstructions specialInstructions { get; set; }
		public object proofOfDeliveryUrl { get; set; }
		public object upsAccessPoint { get; set; }
		public object additionalPackagesCount { get; set; }
		public AttentionNeeded attentionNeeded { get; set; }
		public ShipmentProgressActivity[] shipmentProgressActivities { get; set; }
		public string trackingNumberType { get; set; }
		public object preAuthorizedForReturnData { get; set; }
		public string shipToAddressLblKey { get; set; }
		public object trackSummaryView { get; set; }
		public string senderShipperNumber { get; set; }
		public string internalKey { get; set; }
		public UserOptions userOptions { get; set; }
		public Sendupdatesoptions sendUpdatesOptions { get; set; }
		public string myChoiceUpSellLink { get; set; }
		public object bcdnNumber { get; set; }
		public Promo promo { get; set; }
		public object whatsNextText { get; set; }
		public string packageStatusTimeLbl { get; set; }
		public bool deSepcialTranslation { get; set; }
		public string packageStatusTime { get; set; }
		public object myChoiceToken { get; set; }
		public bool showMycTerms { get; set; }
		public string enrollNum { get; set; }
		public bool showConfirmWindow { get; set; }
		public object confirmWindowLbl { get; set; }
		public object confirmWindowLink { get; set; }
		public object followMyDelivery { get; set; }
		public object fileClaim { get; set; }
		public object viewClaim { get; set; }
		public object flightInformation { get; set; }
		public object voyageInformation { get; set; }
		public object viewDeliveryReceipt { get; set; }
		public bool isInWatchList { get; set; }
		public bool isHistoryUpdateRequire { get; set; }
		public AsrInformation asrInformation { get; set; }
	}

	public class ShipToAddress
	{
		public string streetAddress1 { get; set; }
		public string streetAddress2 { get; set; }
		public string streetAddress3 { get; set; }
		public string city { get; set; }
		public string state { get; set; }
		public object province { get; set; }
		public string country { get; set; }
		public string zipCode { get; set; }
		public string companyName { get; set; }
		public string attentionName { get; set; }
		public bool isAddressCorrected { get; set; }
		public bool isReturnAddress { get; set; }
		public bool isHoldAddress { get; set; }
	}

	public class AdditionalInformation
	{
		public ServiceInformation serviceInformation { get; set; }
		public string weight { get; set; }
		public string weightUnit { get; set; }
		public object codInformation { get; set; }
		public string shippedOrBilledDate { get; set; }
		public object referenceNumbers { get; set; }
		public string postalServiceTrackingID { get; set; }
		public object alternateTrackingNumbers { get; set; }
		public object otherRequestedServices { get; set; }
		public string descriptionOfGood { get; set; }
		public string cargoReady { get; set; }
		public string fileNumber { get; set; }
		public string originPort { get; set; }
		public string destinationPort { get; set; }
		public string estimatedArrival { get; set; }
		public string estimatedDeparture { get; set; }
		public string poNumber { get; set; }
		public string blNumber { get; set; }
		public object appointmentMade { get; set; }
		public object appointmentRequested { get; set; }
		public object appointmentRequestedRange { get; set; }
		public string manifest { get; set; }
		public bool isSmallPackage { get; set; }
		public object shipmentVolume { get; set; }
		public object numberOfPallets { get; set; }
		public string shipmentCategory { get; set; }
		public object pkgSequenceNum { get; set; }
		public object pkgIdentificationCode { get; set; }
		public object pkgID { get; set; }
		public object product { get; set; }
		public object numberOfPieces { get; set; }
		public bool wwef { get; set; }
		public bool wwePostal { get; set; }
		public bool wweParcel { get; set; }
		public object deliveryPreference { get; set; }
		public object liftGateOnDelivery { get; set; }
		public object liftGateOnPickup { get; set; }
		public object pickupDropOffDate { get; set; }
		public object pickupPreference { get; set; }
	}

	public class ServiceInformation
	{
		public string serviceName { get; set; }
		public string serviceLink { get; set; }
		public object serviceAttribute { get; set; }
	}

	public class SpecialInstructions
	{
		public object indonesianLearnMoreUrl { get; set; }
		public object indonesianCustomsUrl { get; set; }
		public object upsPremiumCare { get; set; }
		public string signatureType { get; set; }
		public object codInformation { get; set; }
		public object epra { get; set; }
		public bool isHeavyGoodsNote { get; set; }
		public MyChoiceEligibilty myChoiceEligibilty { get; set; }
		public bool isDisplayDbdMessage { get; set; }
		public bool isDisplayDbdMessageForAnonymous { get; set; }
		public bool isCdiAsr { get; set; }
	}

	public class MyChoiceEligibilty
	{
		public object signNow { get; set; }
		public object shipperRestrictedLbl { get; set; }
		public object cancelShipmentAuthorization { get; set; }
		public object mycTermsUpToDateUrl { get; set; }
	}

	public class AttentionNeeded
	{
		public object[] actions { get; set; }
		public bool isCorrectMyAddress { get; set; }
	}

	public class UserOptions
	{
		public DeliveryOptions deliveryOptions { get; set; }
	}

	public class DeliveryOptions
	{
		public bool isLoggedInMyChoicePage { get; set; }
		public bool isNotLoggedInMyChoicePage { get; set; }
		public bool isInfoNoticePage { get; set; }
		public bool isLoggedInNoneMyChoicePage { get; set; }
		public bool isContactOnlyPage { get; set; }
		public bool isRedirect { get; set; }
		public string login { get; set; }
		public string signUp { get; set; }
		public object driverInstructions { get; set; }
		public object sendSecurityCode { get; set; }
		public object deliveryChanges { get; set; }
		public object siiEligible { get; set; }
		public object upgradeToUpsGround { get; set; }
		public object contactUps { get; set; }
		public object redirect { get; set; }
		public object myChoiceTandCUrl { get; set; }
		public string doappUrl { get; set; }
		public bool dcrEligible { get; set; }
		public NotLoggedInMyChoicePage notLoggedInMyChoicePage { get; set; }
		public object loggedInMyChoicePage { get; set; }
		public bool isIdentityVerification { get; set; }
		public object text { get; set; }
		public string name { get; set; }
		public object url { get; set; }
	}

	public class NotLoggedInMyChoicePage
	{
		public string[] deliveryChangesOptions { get; set; }
		public bool isDriverInstructions { get; set; }
		public bool isDeliveryChanges { get; set; }
		public bool isSignUpLogin { get; set; }
		public bool isInfonoticeNote { get; set; }
	}

	public class Sendupdatesoptions
	{
		public string bridgePageType { get; set; }
		public string modalType { get; set; }
		public string myChoicePreferencesLink { get; set; }
		public bool isDisplayCurrentStatus { get; set; }
		public bool isDisplayUnforeseenEventsOrDelays { get; set; }
		public bool isDisplayShipmentDelivered { get; set; }
		public bool isDisplayPackageReadyForPickup { get; set; }
		public bool isPreCheckedCurrentStatus { get; set; }
		public bool isPreCheckedUnforeseenEventsOrDelays { get; set; }
		public bool isPreCheckedShipmentDelivered { get; set; }
		public bool isPreCheckedPackageReadyForPickup { get; set; }
		public bool isDayBeforeDeliveryAlert { get; set; }
		public bool isDayOfDeliveryAlert { get; set; }
		public bool isDeliveryConfirmationAlert { get; set; }
		public bool isPackageAvailableForPickupAlert { get; set; }
		public bool isDeliveryScheduleUpdateAlert { get; set; }
		public bool isPreCheckedDayBeforeDeliveryAlert { get; set; }
		public bool isPreCheckedDayOfDeliveryAlert { get; set; }
		public bool isPreCheckedDeliveryConfirmationAlert { get; set; }
		public bool isPreCheckedPackageAvailableForPickupAlert { get; set; }
		public bool isPreCheckedDeliveryScheduleUpdateAlert { get; set; }
		public LanguageOption[] languageOptions { get; set; }
		public string defaultSelectedLanguage { get; set; }
		public object email { get; set; }
		public object phoneNumber { get; set; }
		public bool isSMSSupported { get; set; }
		public object recipients { get; set; }
		public object text { get; set; }
		public string name { get; set; }
		public object url { get; set; }
	}

	public class LanguageOption
	{
		public string locale { get; set; }
		public string language { get; set; }
	}

	public class Promo
	{
		public bool isPackagePromotion { get; set; }
		public bool isShipperPromotion { get; set; }
		public object productImage { get; set; }
		public object title { get; set; }
		public object description { get; set; }
		public object shipperURL { get; set; }
		public object shipperLogoURL { get; set; }
	}

	public class AsrInformation
	{
		public object allowDriverRelease { get; set; }
		public object processEDN { get; set; }
	}

	public class ShipmentProgressActivity
	{
		public string date { get; set; }
		public string time { get; set; }
		public string location { get; set; } = null;
		public string activityScan { get; set; }
		public Milestone milestone { get; set; }
		public bool isInOverViewTable { get; set; }
		public object activityAdditionalDescription { get; set; }
		public string trailer { get; set; }
		public bool isDisplayPodLink { get; set; }
		public string actCode { get; set; }
	}

	public class Milestone
	{
		public string name { get; set; }
		public bool isCurrent { get; set; }
		public bool isCompleted { get; set; }
	}

}
