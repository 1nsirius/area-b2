// Namespace: 
private struct FacetsChecker.FacetsCompiler // TypeDefIndex: 2676
{
	// Fields
	private DatatypeImplementation datatype; // 0x0
	private RestrictionFacets derivedRestriction; // 0x4
	private RestrictionFlags baseFlags; // 0x8
	private RestrictionFlags baseFixedFlags; // 0xC
	private RestrictionFlags validRestrictionFlags; // 0x10
	private XmlSchemaDatatype nonNegativeInt; // 0x14
	private XmlSchemaDatatype builtInType; // 0x18
	private XmlTypeCode builtInEnum; // 0x1C
	private bool firstPattern; // 0x20
	private StringBuilder regStr; // 0x24
	private XmlSchemaPatternFacet pattern_facet; // 0x28
	private static readonly FacetsChecker.FacetsCompiler.Map[] c_map; // 0x0

	// Methods

	// RVA: 0x76F798 Offset: 0x76F798 VA: 0x76F798
	public void .ctor(DatatypeImplementation baseDatatype, RestrictionFacets restriction) { }

	// RVA: 0x76F7A0 Offset: 0x76F7A0 VA: 0x76F7A0
	internal void CompileLengthFacet(XmlSchemaFacet facet) { }

	// RVA: 0x76F7A8 Offset: 0x76F7A8 VA: 0x76F7A8
	internal void CompileMinLengthFacet(XmlSchemaFacet facet) { }

	// RVA: 0x76F7B0 Offset: 0x76F7B0 VA: 0x76F7B0
	internal void CompileMaxLengthFacet(XmlSchemaFacet facet) { }

	// RVA: 0x76F7B8 Offset: 0x76F7B8 VA: 0x76F7B8
	internal void CompilePatternFacet(XmlSchemaPatternFacet facet) { }

	// RVA: 0x76F7C0 Offset: 0x76F7C0 VA: 0x76F7C0
	internal void CompileEnumerationFacet(XmlSchemaFacet facet, IXmlNamespaceResolver nsmgr, XmlNameTable nameTable) { }

	// RVA: 0x76F7DC Offset: 0x76F7DC VA: 0x76F7DC
	internal void CompileWhitespaceFacet(XmlSchemaFacet facet) { }

	// RVA: 0x76F7E4 Offset: 0x76F7E4 VA: 0x76F7E4
	internal void CompileMaxInclusiveFacet(XmlSchemaFacet facet) { }

	// RVA: 0x76F7EC Offset: 0x76F7EC VA: 0x76F7EC
	internal void CompileMaxExclusiveFacet(XmlSchemaFacet facet) { }

	// RVA: 0x76F7F4 Offset: 0x76F7F4 VA: 0x76F7F4
	internal void CompileMinInclusiveFacet(XmlSchemaFacet facet) { }

	// RVA: 0x76F7FC Offset: 0x76F7FC VA: 0x76F7FC
	internal void CompileMinExclusiveFacet(XmlSchemaFacet facet) { }

	// RVA: 0x76F804 Offset: 0x76F804 VA: 0x76F804
	internal void CompileTotalDigitsFacet(XmlSchemaFacet facet) { }

	// RVA: 0x76F80C Offset: 0x76F80C VA: 0x76F80C
	internal void CompileFractionDigitsFacet(XmlSchemaFacet facet) { }

	// RVA: 0x76F814 Offset: 0x76F814 VA: 0x76F814
	internal void FinishFacetCompile() { }

	// RVA: 0x76F81C Offset: 0x76F81C VA: 0x76F81C
	private void CheckValue(object value, XmlSchemaFacet facet) { }

	// RVA: 0x76F824 Offset: 0x76F824 VA: 0x76F824
	internal void CompileFacetCombinations() { }

	// RVA: 0x76F82C Offset: 0x76F82C VA: 0x76F82C
	private void CopyFacetsFromBaseType() { }

	// RVA: 0x76F834 Offset: 0x76F834 VA: 0x76F834
	private object ParseFacetValue(XmlSchemaDatatype datatype, XmlSchemaFacet facet, string code, IXmlNamespaceResolver nsmgr, XmlNameTable nameTable) { }

	// RVA: 0x19E34E0 Offset: 0x19E34E0 VA: 0x19E34E0
	private static string Preprocess(string pattern) { }

	// RVA: 0x76F858 Offset: 0x76F858 VA: 0x76F858
	private void CheckProhibitedFlag(XmlSchemaFacet facet, RestrictionFlags flag, string errorCode) { }

	// RVA: 0x76F874 Offset: 0x76F874 VA: 0x76F874
	private void CheckDupFlag(XmlSchemaFacet facet, RestrictionFlags flag, string errorCode) { }

	// RVA: 0x76F890 Offset: 0x76F890 VA: 0x76F890
	private void SetFlag(XmlSchemaFacet facet, RestrictionFlags flag) { }

	// RVA: 0x76F898 Offset: 0x76F898 VA: 0x76F898
	private void SetFlag(RestrictionFlags flag) { }

	// RVA: 0x19E3F3C Offset: 0x19E3F3C VA: 0x19E3F3C
	private static void .cctor() { }
}
