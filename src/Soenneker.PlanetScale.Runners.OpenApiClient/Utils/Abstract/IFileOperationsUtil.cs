using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.PlanetScale.Runners.OpenApiClient.Utils.Abstract;

public interface IFileOperationsUtil
{
    /// <summary>
    /// Downloads the PlanetScale specification, generates the client, and builds it.
    /// Set PlanetScale:LocalDirectory to regenerate an existing local client repository without pushing.
    /// Otherwise, clones the client repository and pushes the generated update after a successful build.
    /// </summary>
    ValueTask Process(CancellationToken cancellationToken = default);
}
