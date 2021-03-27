using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Providers.GitPath.Interface;

namespace Providers.GitPath
{
    public class LibGit2SharpService : IGitDiretorioRemotoService
    {
      
        public string ObterUrlGithub()
        {
            var solucaoDiretorio = Directory.GetParent(Environment.CurrentDirectory).FullName;
            string repositorioDiretorio = LibGit2Sharp.Repository.Discover(solucaoDiretorio);
            var repositorio = new LibGit2Sharp.Repository(repositorioDiretorio);
            var githubUrlRemota = repositorio.Network.Remotes.FirstOrDefault(r => r.Name == "origin");
            string githubUrl = githubUrlRemota.Url;

            return githubUrl;
        }


        public string FormatarUrlGithub(string githubRepositorioUrl)
        {
            githubRepositorioUrl = Regex.Replace(githubRepositorioUrl, @"\.git$", "");

            //Caso tenha usado SSH ao inves de HTTPS
            if(githubRepositorioUrl.Contains("git@"))
            {
                githubRepositorioUrl = Regex.Replace(githubRepositorioUrl, "^git@", "https://");
                githubRepositorioUrl = Regex.Replace(githubRepositorioUrl, "^https:git@", "https://");
                githubRepositorioUrl = Regex.Replace(githubRepositorioUrl, ".com:", ".com/");
            }

            return githubRepositorioUrl;
        }
    }
}
