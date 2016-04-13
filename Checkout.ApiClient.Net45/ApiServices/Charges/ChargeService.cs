using System.Threading.Tasks;
using Checkout.ApiServices.Charges.RequestModels;
using Checkout.ApiServices.Charges.ResponseModels;
using Checkout.ApiServices.SharedModels;

namespace Checkout.ApiServices.Charges
{
    public class ChargeService
    {
        /// <summary>
        /// Creates a charge with full card details.
        /// </summary>
        public HttpResponse<Charge> ChargeWithCard(CardCharge requestModel)
        {
            return new ApiHttpClient().PostRequest<Charge>(ApiUrls.CardCharge, AppSettings.SecretKey,requestModel);
        }

        /// <summary>
        /// Creates a charge with card id.
        /// </summary>
        public HttpResponse<Charge> ChargeWithCardId(CardIdCharge requestModel)
        {
            return new ApiHttpClient().PostRequest<Charge>(ApiUrls.CardCharge, AppSettings.SecretKey, requestModel);
        }

        /// <summary>
        /// Creates a charge with card token.
        /// </summary>
        public HttpResponse<Charge> ChargeWithCardToken(CardTokenCharge requestModel)
        {
            return new ApiHttpClient().PostRequest<Charge>(ApiUrls.CardTokenCharge, AppSettings.SecretKey, requestModel);
        }

        /// <summary>
        /// Creates a charge with the default card of the customer.
        /// </summary>
        public HttpResponse<Charge> ChargeWithDefaultCustomerCard(DefaultCardCharge requestModel)
        {
            return new ApiHttpClient().PostRequest<Charge>(ApiUrls.DefaultCardCharge, AppSettings.SecretKey, requestModel);
        }

        /// <summary>
        /// Voids an authorised charge. If charge has been captured you cannot perform void operation.
        /// </summary>
        public HttpResponse<Void> VoidCharge(string chargeId, ChargeVoid requestModel)
        {
            var voidChargeApiUri = string.Format(ApiUrls.VoidCharge, chargeId);
            return new ApiHttpClient().PostRequest<Void>(voidChargeApiUri, AppSettings.SecretKey, requestModel);
        }

        /// <summary>
        /// Refunds a captured charge.
        /// </summary>
        public HttpResponse<Refund> RefundCharge(string chargeId,ChargeRefund requestModel)
        {
            var chargeRefundsApiUri = string.Format(ApiUrls.RefundCharge, chargeId);
            return new ApiHttpClient().PostRequest<Refund>(chargeRefundsApiUri, AppSettings.SecretKey, requestModel);
        }

        /// <summary>
        /// Captures an authorised charge.
        /// </summary>
        public HttpResponse<Capture> CaptureCharge(string chargeId, ChargeCapture requestModel)
        {
            var captureChargesApiUri = string.Format(ApiUrls.CaptureCharge, chargeId);
            return new ApiHttpClient().PostRequest<Capture>(captureChargesApiUri, AppSettings.SecretKey, requestModel);
        }

        /// <summary>
        /// Updates a charge.
        /// </summary>
        public HttpResponse<OkResponse> UpdateCharge(string chargeId, ChargeUpdate requestModel)
        {
            var updateChargesApiUri = string.Format(ApiUrls.Charge, chargeId);
            return new ApiHttpClient().PutRequest<OkResponse>(updateChargesApiUri, AppSettings.SecretKey, requestModel);
        }

        /// <summary>
        /// Retrieves a charge by chargeId
        /// </summary>
        public HttpResponse<Charge> GetCharge(string chargeId)
        {
            var getChargeUri = string.Format(ApiUrls.Charge, chargeId);
            return new ApiHttpClient().GetRequest<Charge>(getChargeUri, AppSettings.SecretKey);
        }

        /// <summary>
        /// Retrieves charge history by chargeId
        /// </summary>
        public HttpResponse<ChargeHistory> GetChargeHistory(string chargeId)
        {
            var getChargeHistoryUri = string.Format(ApiUrls.ChargeHistory, chargeId);
            return new ApiHttpClient().GetRequest<ChargeHistory>(getChargeHistoryUri, AppSettings.SecretKey);
        }

        /// <summary>
        /// Retrieves a charge by payment token or chargeId
        /// </summary>
        public HttpResponse<Charge> VerifyCharge(string paymentToken)
        {
            string chargeVerifyApiUri = string.Format(ApiUrls.Charge, paymentToken);

            return new ApiHttpClient().GetRequest<Charge>(chargeVerifyApiUri, AppSettings.SecretKey);
        }

        /// <summary>
        /// Creates a charge with full card details asynchronously.
        /// </summary>
        public async Task<HttpResponse<Charge>> ChargeWithCardAsync(CardCharge requestModel)
        {
            return await new ApiHttpClient().PostRequestAsync<Charge>(ApiUrls.CardCharge, AppSettings.SecretKey, requestModel);
        }

        /// <summary>
        /// Creates a charge with card id asynchronously.
        /// </summary>
        public async Task<HttpResponse<Charge>> ChargeWithCardIdAsync(CardIdCharge requestModel)
        {
            return await new ApiHttpClient().PostRequestAsync<Charge>(ApiUrls.CardCharge, AppSettings.SecretKey, requestModel);
        }

        /// <summary>
        /// Creates a charge with card token asynchronously.
        /// </summary>
        public async Task<HttpResponse<Charge>> ChargeWithCardTokenAsync(CardTokenCharge requestModel)
        {
            return await new ApiHttpClient().PostRequestAsync<Charge>(ApiUrls.CardTokenCharge, AppSettings.SecretKey, requestModel);
        }

        /// <summary>
        /// Creates a charge with the default card of the customer asynchronously.
        /// </summary>
        public async Task<HttpResponse<Charge>> ChargeWithDefaultCustomerCardAsync(DefaultCardCharge requestModel)
        {
            return await new ApiHttpClient().PostRequestAsync<Charge>(ApiUrls.DefaultCardCharge, AppSettings.SecretKey, requestModel);
        }

        /// <summary>
        /// Voids an authorised charge asynchronously. If charge has been captured you cannot perform void operation.
        /// </summary>
        public async Task<HttpResponse<Void>> VoidChargeAsync(string chargeId, ChargeVoid requestModel)
        {
            var voidChargeApiUri = string.Format(ApiUrls.VoidCharge, chargeId);
            return await new ApiHttpClient().PostRequestAsync<Void>(voidChargeApiUri, AppSettings.SecretKey, requestModel);
        }

        /// <summary>
        /// Refunds a captured charge asynchronously.
        /// </summary>
        public async Task<HttpResponse<Refund>> RefundChargeAsync(string chargeId, ChargeRefund requestModel)
        {
            var chargeRefundsApiUri = string.Format(ApiUrls.RefundCharge, chargeId);
            return await new ApiHttpClient().PostRequestAsync<Refund>(chargeRefundsApiUri, AppSettings.SecretKey, requestModel);
        }

        /// <summary>
        /// Captures an authorised charge asynchronously.
        /// </summary>
        public async Task<HttpResponse<Capture>> CaptureChargeAsync(string chargeId, ChargeCapture requestModel)
        {
            var captureChargesApiUri = string.Format(ApiUrls.CaptureCharge, chargeId);
            return await new ApiHttpClient().PostRequestAsync<Capture>(captureChargesApiUri, AppSettings.SecretKey, requestModel);
        }

        /// <summary>
        /// Updates a charge asynchronously.
        /// </summary>
        public async Task<HttpResponse<OkResponse>> UpdateChargeAsync(string chargeId, ChargeUpdate requestModel)
        {
            var updateChargesApiUri = string.Format(ApiUrls.Charge, chargeId);
            return await new ApiHttpClient().PutRequestAsync<OkResponse>(updateChargesApiUri, AppSettings.SecretKey, requestModel);
        }

        /// <summary>
        /// Retrieves a charge by chargeId asynchronously.
        /// </summary>
        public async Task<HttpResponse<Charge>> GetChargeAsync(string chargeId)
        {
            var getChargeUri = string.Format(ApiUrls.Charge, chargeId);
            return await new ApiHttpClient().GetRequestAsync<Charge>(getChargeUri, AppSettings.SecretKey);
        }

        /// <summary>
        /// Retrieves charge history by chargeId asynchronously
        /// </summary>
        public async Task<HttpResponse<ChargeHistory>> GetChargeHistoryAsync(string chargeId)
        {
            var getChargeHistoryUri = string.Format(ApiUrls.ChargeHistory, chargeId);
            return await new ApiHttpClient().GetRequestAsync<ChargeHistory>(getChargeHistoryUri, AppSettings.SecretKey);
        }

        /// <summary>
        /// Retrieves a charge by payment token or chargeId asynchronously
        /// </summary>
        public async Task<HttpResponse<Charge>> VerifyChargeAsync(string paymentToken)
        {
            var chargeVerifyApiUri = string.Format(ApiUrls.Charge, paymentToken);
            return await new ApiHttpClient().GetRequestAsync<Charge>(chargeVerifyApiUri, AppSettings.SecretKey);
        }
    }
}