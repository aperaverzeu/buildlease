import AddressInfo from "./AddressInfo";

export default interface CustomerInfo {
    CompanyName: string,
    CompanyImagePath: string,
    RepresentativeName: string,
    RepresentativeImagePath: string,
    ContactInfo: string,
    JuridicalAddress: AddressInfo,
    DeliveryAddresses: AddressInfo[],
}
