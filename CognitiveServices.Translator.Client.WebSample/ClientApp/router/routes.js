import Home from 'pages/home'
import About from 'pages/about'
import Translate from 'pages/translate'
import NotFound404 from 'pages/404'

// Order matter since there's the language optional tag. That's why home is the
// latest with the catch{all}.
export const routes = [
  { name: '404', path: '/404', component: NotFound404, meta: { order: null } },
  { name: 'Translate', path: '/:lang?/translate', component: Translate, i18n: 'route.translate', icon: 'icon-language', meta: { order: 2 } },
  { name: 'about', path: '/:lang?/about', component: About, i18n: 'route.about', icon: 'icon-about', meta: { order: 3 } },
  { name: 'home', path: '/:lang?', component: Home, display: 'Home', i18n: 'route.home', icon: 'icon-home', meta: { order: 1 } },
  { name: 'catchAll', path: '*', redirect: '/404', meta: { order: null } }
]
