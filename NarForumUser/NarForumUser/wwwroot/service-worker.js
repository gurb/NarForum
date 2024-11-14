self.addEventListener('install', (event) => {
    console.log('Service Worker installing...');
    event.waitUntil(
        caches.open('blazor-cache-v1').then((cache) => {
            // Cache’e alınacak dosyalar
            return cache.addAll([
                '/_framework/blazor.web.js',  // Blazor WebAssembly dosyası
                '/css/app.css',// CSS dosyası
                '/css/bootstrap.min.css', // bootstrap min css
                '/NarForumUser.styles.css',         // Diğer gerekli stil dosyaları
                '/js/utils.js'                      // JavaScript dosyası
            ]);
        })
    );
});

self.addEventListener('fetch', (event) => {
    event.respondWith(
        caches.match(event.request).then((cachedResponse) => {
            if (cachedResponse) {
                console.log(event.request);
                return cachedResponse;
            }
            // Cache'de yoksa ağdan isteği yap
            return fetch(event.request);
        })
    );
});
