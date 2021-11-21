export default interface AttributeFilter {
    AttributeId: number,
    ValueNumberLowerBound: number | null,
    ValueNumberUpperBound: number | null,
    ValueStringAllowed: string[] | null,
}
