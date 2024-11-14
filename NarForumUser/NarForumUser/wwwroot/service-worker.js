self.addEventListener('install', (event) => {
    console.log('Service Worker installing...');
    event.waitUntil(
        caches.open('blazor-cache-v1').then((cache) => {
            // Cache’e alınacak dosyalar
            return cache.addAll([
                '/_framework/blazor.web.js', 
                '/css/app.css',
                '/css/bootstrap.min.css',
                '/NarForumUser.styles.css',       
                '/js/utils.js'                     
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
            return fetch(event.request);
        })
    );
});
