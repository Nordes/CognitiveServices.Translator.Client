import Vue from 'vue'
import Vuex from 'vuex'
import I18n from './modules/i18n'
import CognitiveTranslator from './modules/translator'

Vue.use(Vuex)

export default new Vuex.Store({
  modules: {
    i18n: I18n,
    translator: CognitiveTranslator
  }
})
