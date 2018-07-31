using Newtonsoft.Json;

namespace AndroidBinderator
{
	public class MavenArtifactConfig
	{
		public MavenArtifactConfig()
		{
		}

		public MavenArtifactConfig(string groupId, string artifactId, string version, string nugetPackageId = null, string nugetVersion = null)
		{
			GroupId = groupId;
			ArtifactId = artifactId;
			Version = version;
			NugetVersion = nugetVersion ?? version;
			NugetPackageId = nugetPackageId;
		}

		[JsonProperty("groupId")]
		public string GroupId { get; set; }

		[JsonProperty("artifactId")]
		public string ArtifactId { get; set; }

		[JsonProperty("version")]
		public string Version { get; set; }

		[JsonProperty("nugetVersion")]
		public string NugetVersion { get; set; }

		[JsonProperty("nugetId")]
		public string NugetPackageId { get; set; }

		[JsonProperty("dependencyOnly")]
		public bool DependencyOnly { get; set; } = false;

		[JsonProperty("assemblyName")]
		public string AssemblyName { get; set; } = null;
	}
}
