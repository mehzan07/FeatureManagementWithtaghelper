using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.FeatureManagement;

namespace FeatureManagement.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IFeatureManager _featureManager;

        public IndexModel(ILogger<IndexModel> logger, IFeatureManager featureManager)
        {
            _logger = logger;
            _featureManager = featureManager;
        }

        public async void OnGet()
        {
            _logger.LogInformation($"feature value {await _featureManager.IsEnabledAsync(FeatureFlags.SecretFeature)}");
        }
    }

    public static class FeatureFlags
    {
        public static readonly string SecretFeature = nameof(SecretFeature);
    }
}
