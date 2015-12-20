using Ionic.Zip;

public static class CompressionTools {

	/// <summary>
	/// Unzips the specified zip to output directory.
	/// </summary>
	/// <param name="zipToUnpack">Zip to unpack.</param>
	/// <param name="outputDirectory">Output directory.</param>
	public static void unzip(string zipToUnpack, string outputDirectory) {
		using (ZipFile zipFile = ZipFile.Read (zipToUnpack))
			foreach (ZipEntry entry in zipFile)
				entry.Extract(outputDirectory, ExtractExistingFileAction.OverwriteSilently);
	}
}
