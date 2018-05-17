import Translate from 'components/translate-page'
import HomePage from 'components/home-page'

export const routes = [
  { name: 'home', path: '/', component: HomePage, display: 'Home', icon: 'home' },
  { name: 'translate', path: '/translate', component: Translate, display: 'Translate', icon: 'list' }
]
