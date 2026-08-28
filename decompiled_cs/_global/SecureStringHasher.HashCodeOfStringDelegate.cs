// Namespace: 
private sealed class SecureStringHasher.HashCodeOfStringDelegate : MulticastDelegate // TypeDefIndex: 2314
{
	// Methods

	// RVA: 0x1586ADC Offset: 0x1586ADC VA: 0x1586ADC
	public void .ctor(object object, IntPtr method) { }

	// RVA: 0x1586104 Offset: 0x1586104 VA: 0x1586104 Slot: 12
	public virtual int Invoke(string s, int sLen, long additionalEntropy) { }

	// RVA: 0x1586AF0 Offset: 0x1586AF0 VA: 0x1586AF0 Slot: 13
	public virtual IAsyncResult BeginInvoke(string s, int sLen, long additionalEntropy, AsyncCallback callback, object object) { }

	// RVA: 0x1586BBC Offset: 0x1586BBC VA: 0x1586BBC Slot: 14
	public virtual int EndInvoke(IAsyncResult result) { }
}
