using System;
using System.Collections.Generic;
using System.Text;

namespace AndroidBinderator
{
    public static class SolutionFileBuilder
    {
        public static string Build (BindingConfig config, Dictionary<string, BindingProjectModel> projects)
        {
            var s = new StringBuilder();

            s.AppendLine();
            s.AppendLine("Microsoft Visual Studio Solution File, Format Version 12.00");
            s.AppendLine("# Visual Studio 2012");

            //Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "@(project.Name)", "@(project.Name)\@(project.Name).csproj", "@(project.Id)"
            foreach (var project in projects)
            {
                var groupId = project.Value.MavenGroupId;
                var name = project.Value.Name;

                s.AppendLine("Project(\"{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}\") = \"" + name + "\", \"" + project.Key + "\", \"{" + project.Value.Id + "}\"");
                s.AppendLine("EndProject");
            }

            s.AppendLine("Global");

            s.AppendLine("\tGlobalSection(SolutionConfigurationPlatforms) = preSolution");
            s.AppendLine("\t\tDebug|Any CPU = Debug|Any CPU");
            s.AppendLine("\t\tRelease|Any CPU = Release|Any CPU");
            s.AppendLine("\tEndGlobalSection");

            s.AppendLine("\tGlobalSection(ProjectConfigurationPlatforms) = postSolution");
            foreach (var project in projects) {
                s.AppendLine("\t\t{" + project.Value.Id + "}.Debug|Any CPU.ActiveCfg = Debug|Any CPU");
                s.AppendLine("\t\t{" + project.Value.Id + "}.Debug|Any CPU.Build.0 = Debug|Any CPU");
                s.AppendLine("\t\t{" + project.Value.Id + "}.Release|Any CPU.ActiveCfg = Release|Any CPU");
                s.AppendLine("\t\t{" + project.Value.Id + "}.Release|Any CPU.Build.0 = Release|Any CPU");
            }
            s.AppendLine("\tEndGlobalSection");

            s.AppendLine("EndGlobal");

            return s.ToString();
        }
    }
}
