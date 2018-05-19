import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

// TYPES
const COGNITIVE_SVC_KEY = 'COGNITIVE_SVC_KEY'
const TRANSLATE_TYPE = 'TRANSLATE_TYPE'

// STATE
const state = {
  cognitiveServicesKey: '',
  translateType: 'plain'
}

// MUTATIONS
const mutations = {
  [COGNITIVE_SVC_KEY] (state, obj) {
    state.cognitiveServicesKey = obj.cognitiveServicesKey
  },

  [TRANSLATE_TYPE] (state, obj) {
    state.translateType = obj.translateType
  }
}

// ACTIONS
const actions = ({
  setCognitiveSvcKey ({ commit }, obj) {
    commit(COGNITIVE_SVC_KEY, obj)
  },

  setTranslateType ({ commit }, obj) {
    commit(TRANSLATE_TYPE, obj)
  }
})

export default new Vuex.Store({
  state,
  mutations,
  actions
})
