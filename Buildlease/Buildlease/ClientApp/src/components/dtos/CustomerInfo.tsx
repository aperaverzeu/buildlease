import AddressInfo from "./AddressInfo";

export default interface CustomerInfo {
    CompanyName: string,
    RepresentativeName: string,
    ContactInfo: string,
    JuridicalAddress: AddressInfo,
    DeliveryAddresses: AddressInfo[],
}
