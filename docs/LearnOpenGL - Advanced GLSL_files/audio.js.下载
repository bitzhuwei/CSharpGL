(function () {
    var scripts = document.getElementsByTagName('script');
    var script = scripts[scripts.length - 1];
    var scriptURL = script.src;
    var u = (new URL(scriptURL)).searchParams;
    
    if (u === undefined || u.size == 0) {
        u = (new URL(document.location)).searchParams;
    }

    var gdpr = u.get("gdpr") ?? '';
    var gdprcs = u.get("gdpr_consent") ?? '';
    var usp = u.get("us_privacy") ?? '';
    var gpp = u.get("gpp") ?? '';
    var gppsid = u.get("gpp_sid") ?? '';

    let scriptUrls = [
        {
            url: 'https://playerservices.live.streamtheworld.com/api/idsync.js?stationId=637053&gdpr=' + gdpr + '&gdpr_consent=' + gdprcs + '&us_privacy=' + usp,
            loaded: false
        },
        {
            url: 'https://synchrobox.adswizz.com/register2.php',
            loaded: false
        },
        {
            url: 'https://delivery-cdn-cf.adswizz.com/adswizz/js/SynchroClient2.js',
            loaded: false
        }
    ];

    function createPixel(u) {
        let img = document.createElement('img');
        img.src = u;
        document.body.appendChild(img);
    }

    function createPixels() {
        fetch('https://yield-op-idsync.live.streamtheworld.com/partnerIds', {credentials: 'include', method: 'GET'})
                .then(response => response.json())
                .then(function (data) {
                    if (data && (data['an-uid'] || data['triton-uid'])) {
                        createPixel('https://x.serverbid.com/usersync?ttt=1&src=1&cspi=0&cn=50&gdpr=' + gdpr + '&gdpr_consent=' + gdprcs + '&us_privacy=' + usp + '&gpp=' + gpp + '&gpp_sid=' + gppsid + '&dpui=' + encodeURIComponent(JSON.stringify(data)));
                    }
                });
        createPixel('https://x.serverbid.com/usersync?ttt=1&src=1&cspi=0&cn=5848&gdpr=' + gdpr + '&gdpr_consent=' + gdprcs + '&us_privacy=' + usp + '&gpp=' + gpp + '&gpp_sid=' + gppsid + '&dpui=' + com_adswizz_synchro_getListenerId());
        createPixel('https://sync.1rx.io/usersync2/rmpssp?sub=consumable&gdpr=' + gdpr + '&gdpr_consent=' + gdprcs + '&us_privacy=' + usp);
    }

    scriptUrls.forEach((url) => {
        let scriptEl = document.createElement('script');
        scriptEl.setAttribute('src', url.url);
        scriptEl.setAttribute('type', 'text/javascript');
        scriptEl.setAttribute('async', true);
        document.body.appendChild(scriptEl);
        scriptEl.addEventListener('load', () => {
            scriptUrls.find(u => u.url === url.url).loaded = true;
            if (scriptUrls.every(u => u.loaded === true)) {
                createPixels();
            }
        })
    });

})();