// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// JS d'interactivité pour la page Posts (Ajax + rendu dynamique)
(function () {
    function field(obj, pascal, camel) {
        if (!obj) return undefined;
        if (Object.prototype.hasOwnProperty.call(obj, pascal)) return obj[pascal];
        if (Object.prototype.hasOwnProperty.call(obj, camel)) return obj[camel];
        return obj[camel] || obj[pascal];
    }
    function createPostCard(post) {
        var titre = field(post, 'Titre', 'titre') || '';
        var contenu = field(post, 'Contenu', 'contenu') || '';
        var auteurText = field(post, 'Auteur', 'auteur') || 'Anonyme';
        var dateText = field(post, 'DateCreation', 'dateCreation') || '';
        var truncated = contenu && contenu.length > 100 ? contenu.substring(0, 100) + '...' : contenu;

        var col = document.createElement('div');
        col.className = 'col-12 col-md-6 col-lg-4 mb-4';
        col.innerHTML =
            '<div class="card h-100 shadow-sm">' +
            '  <div class="card-header bg-primary text-white">' +
            '    <h5 class="card-title mb-0">' + escapeHtml(titre) + '</h5>' +
            '  </div>' +
            '  <div class="card-body">' +
            '    <p class="card-text">' + escapeHtml(truncated || '') + '</p>' +
            '    <div class="d-flex justify-content-between align-items-center">' +
            '      <small class="text-muted"><i class="fas fa-user"></i> ' + escapeHtml(auteurText) + '</small>' +
            '      <small class="text-muted"><i class="fas fa-calendar"></i> ' + escapeHtml(dateText) + '</small>' +
            '    </div>' +
            '  </div>' +
            '</div>';
        return col;
    }

    function renderPosts(posts) {
        var container = document.getElementById('postsContainer');
        if (!container) return;
        container.innerHTML = '';
        if (!posts || posts.length === 0) {
            var info = document.createElement('div');
            info.className = 'col-12';
            info.innerHTML = '<div class="alert alert-info text-center"><i class="fas fa-info-circle"></i> Aucun post disponible. Créez votre premier post !</div>';
            container.appendChild(info);
            return;
        }
        posts.forEach(function (p) { container.appendChild(createPostCard(p)); });
    }

    function showAlert(type, message) {
        var zone = document.getElementById('alertZone');
        if (!zone) return;
        zone.innerHTML =
            '<div class="alert alert-' + type + ' alert-dismissible fade show" role="alert">' +
            '  ' + message +
            '  <button type="button" class="btn-close" data-bs-dismiss="alert"></button>' +
            '</div>';
    }

    function getCsrfToken() {
        var form = document.getElementById('postForm');
        if (!form) return null;
        var tokenInput = form.querySelector('input[name="__RequestVerificationToken"]');
        return tokenInput ? tokenInput.value : null;
    }

    function toggleSubmitLoading(isLoading) {
        var btn = document.getElementById('submitBtn');
        if (!btn) return;
        var defaultText = btn.querySelector('.default-text');
        var loadingText = btn.querySelector('.loading-text');
        btn.disabled = isLoading;
        if (defaultText && loadingText) {
            defaultText.classList.toggle('d-none', isLoading);
            loadingText.classList.toggle('d-none', !isLoading);
        }
    }

    function escapeHtml(text) {
        var map = { '&': '&amp;', '<': '&lt;', '>': '&gt;', '"': '&quot;', "'": '&#039;' };
        return String(text || '').replace(/[&<>"']/g, function (m) { return map[m]; });
    }

    function fetchPosts() {
        return fetch('/Post/ListJson', { headers: { 'Accept': 'application/json' } })
            .then(function (res) { return res.json(); })
            .then(function (json) {
                if (!json || json.success !== true) throw new Error('Réponse invalide');
                renderPosts(json.data || []);
                var info = document.getElementById('lastRefreshInfo');
                if (info) {
                    var now = new Date();
                    var hh = String(now.getHours()).padStart(2, '0');
                    var mm = String(now.getMinutes()).padStart(2, '0');
                    var ss = String(now.getSeconds()).padStart(2, '0');
                    info.textContent = 'Dernier rafraîchissement à ' + hh + ':' + mm + ':' + ss;
                }
            })
            .catch(function () {
                showAlert('danger', '<i class="fas fa-exclamation-triangle"></i> Impossible de charger les posts.');
            });
    }

    // plus de formulaire sur la page feed

    document.addEventListener('DOMContentLoaded', function () {
        if (document.getElementById('postsContainer')) {
            fetchPosts();
            var refreshBtn = document.getElementById('refreshBtn');
            if (refreshBtn) {
                refreshBtn.addEventListener('click', function () { fetchPosts(); });
            }
            setInterval(fetchPosts, 30000);
        }
    });
})();
