const COGNITIVE_SVC_KEY = 'COGNITIVE_SVC_KEY'
const COGNITIVE_TRANSLATE_TYPE = 'COGNITIVE_TRANSLATE_TYPE'

// Module example. This is also based on the official documentation at https://vuex.vuejs.org/guide/modules.html
export default {
  namespaced: true,

  state: {
    cognitiveServicesKey: '',
    translateType: 'plain'
  },

  mutations: {
    [COGNITIVE_SVC_KEY] (state, obj) {
      state.cognitiveServicesKey = obj.cognitiveServicesKey
    },

    [COGNITIVE_TRANSLATE_TYPE] (state, obj) {
      state.translateType = obj.translateType
    }
  },

  actions: {
    setCognitiveSvcKey ({ commit }, obj) {
      commit(COGNITIVE_SVC_KEY, obj)
    },

    setTranslateType ({ commit }, obj) {
      commit(COGNITIVE_TRANSLATE_TYPE, obj)
    }
  },

  getters: {
  },

  modules: {
    // Declare sub-modules
  }
}
